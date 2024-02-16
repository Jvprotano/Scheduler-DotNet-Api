using Bie.Business.Models;

namespace Bie.Business.Interfaces.Services;
public interface ISchedulingService : IService<Scheduling>
{
    Task<IEnumerable<Scheduling>> GetAllOpenByCompanyIdAsync(string companyId, DateOnly initialDate, DateOnly finalDate);
    Task<IEnumerable<TimeOnly>> GetAvailableTimesAsync(string companyId, string serviceSelected, DateOnly date);
}