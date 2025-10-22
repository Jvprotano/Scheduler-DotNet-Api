using Agende.Business.Interfaces.Repositories;
using Agende.Business.Interfaces.Repositories.Base;
using Agende.Business.Interfaces.Services;
using Agende.Business.Models;
using Agende.Business.Services.Base;

namespace Agende.Business.Services;
public class SchedulingService : Service<Scheduling>, ISchedulingService
{
    private readonly ISchedulingRepository _repositoryScheduling;
    private readonly ICompanyOpeningHoursRepository _repositoryCompanyOpeningHours;
    private readonly ICompanyService _serviceCompany;

    public SchedulingService(IRepository<Scheduling> repositoryBase, ISchedulingRepository repositoryScheduling,
    ICompanyOpeningHoursRepository repositoryCompanyOpeningHours, ICompanyService serviceCompany) : base(repositoryBase)
    {
        _repositoryScheduling = repositoryScheduling;
        _repositoryCompanyOpeningHours = repositoryCompanyOpeningHours;
        _serviceCompany = serviceCompany;
    }
    public override void Validate(Scheduling entity)
    {
        if (string.IsNullOrWhiteSpace(entity.CompanyId))
            throw new Exception("Company is required");
        if (string.IsNullOrWhiteSpace(entity.CustomerId))
            throw new Exception("Customer is required");
        if (entity.Date == default)
            throw new Exception("Scheduled date is required");
        if (string.IsNullOrWhiteSpace(entity.ServicesOfferedId))
            throw new Exception("Service is required");

        base.Validate(entity);
    }

    public override Task SaveAsync(Scheduling entity)
    {
        return base.SaveAsync(entity);
    }

    public async Task<IEnumerable<Scheduling>> GetAllOpenByCompanyIdAsync(string companyId, DateOnly initialDate, DateOnly finalDate)
    {
        return await _repositoryScheduling.GetAllOpenByCompanyIdAsync(companyId, initialDate, finalDate);
    }

    public async Task<IEnumerable<string>> GetAvailableTimesAsync(string companyId, string serviceSelectedId, DateOnly date, string? professionalId = null)
    {
        List<CompanyOpeningHours> openingHours = _repositoryCompanyOpeningHours.GetByDayOfWeek(companyId, date.DayOfWeek);

        List<TimeOnly> availableTimes = new();

        if (openingHours.Count > 0)
        {
            Company company = await _serviceCompany.GetByIdAsync(companyId);

            CompanyServiceOffered? serviceOffered = company.ServicesOffered.Where(c => c.Id == serviceSelectedId).FirstOrDefault();

            if (serviceOffered == null)
                throw new ArgumentNullException("Service not found");

            var shortestServiceDuration = new TimeOnly(0, 10, 0);

            if (date == DateOnly.FromDateTime(DateTime.Now))
                openingHours.RemoveAll(c => c.OpeningHour < TimeOnly.FromDateTime(DateTime.Now) && c.ClosingHour < TimeOnly.FromDateTime(DateTime.Now));

            foreach (var item in openingHours)
            {
                if (item.OpeningHour == item.ClosingHour)
                    continue;
                if (item.OpeningHour > item.ClosingHour)
                    throw new Exception("Opening hour cannot be greater than closing hour");

                if (date == DateOnly.FromDateTime(DateTime.Now) && item.OpeningHour < TimeOnly.FromDateTime(DateTime.Now))
                    item.OpeningHour = TimeOnly.FromDateTime(DateTime.Now);

                var opening = item.OpeningHour;
                var closing = item.ClosingHour;

                while (opening <= TimeOnly.FromTimeSpan(closing - serviceOffered.Duration))
                {
                    availableTimes.Add(opening);
                    opening = opening.Add(shortestServiceDuration.ToTimeSpan());
                }
            }

            List<Scheduling> busyTimes = (await _repositoryScheduling.GetAllByDateAsync(companyId, date, professionalId)).ToList();

            if (date == DateOnly.FromDateTime(DateTime.Now))
                availableTimes.RemoveAll(c => c < TimeOnly.FromDateTime(DateTime.Now));

            foreach (var item in busyTimes)
            {
                var scheduledHour = item.Time;
                var scheduledDuration = item.ServiceOffered?.Duration;

                TimeOnly finalBusyTime = scheduledHour.Add(scheduledDuration.GetValueOrDefault().ToTimeSpan());

                availableTimes.RemoveAll(c => c >= scheduledHour && c <= finalBusyTime);
            }
        }

        return availableTimes.Select(t => t.ToString("HH:mm"));
    }
}