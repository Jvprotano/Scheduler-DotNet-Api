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
    public void Validate(Scheduling entity)
    {
        if (entity.CompanyId == Guid.Empty)
            throw new Exception("Company is required");
        if (entity.CustomerId == Guid.Empty)
            throw new Exception("Customer is required");
        if (entity.Date == default)
            throw new Exception("Scheduled date is required");
        if (entity.ServicesOfferedId == Guid.Empty)
            throw new Exception("Service is required");
    }

    public override Task CreateAsync(Scheduling entity)
    {
        return base.CreateAsync(entity);
    }

    public async Task<IEnumerable<Scheduling>> GetAllOpenByCompanyIdAsync(Guid companyId, DateOnly initialDate, DateOnly finalDate)
    {
        return await _repositoryScheduling.GetAllOpenByCompanyIdAsync(companyId, initialDate, finalDate);
    }

    public async Task<IEnumerable<string>> GetAvailableTimesAsync(Guid companyId, Guid serviceSelectedId, DateOnly date, Guid? professionalId = null)
    {
        List<CompanyOpeningHours> openingHours = _repositoryCompanyOpeningHours.GetByDayOfWeek(companyId, date.DayOfWeek);

        List<TimeOnly> availableTimes = [];

        if (openingHours.Count > 0)
        {
            Company company = await _serviceCompany.GetByIdAsync(companyId);

            if (company == null)
                throw new ArgumentNullException("Company not found");

            if (company.ServicesOffered == null || company.ServicesOffered.Count == 0)
                throw new ArgumentNullException("Company has no services offered");

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
                    throw new InvalidDataException("Opening hour cannot be greater than closing hour");

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