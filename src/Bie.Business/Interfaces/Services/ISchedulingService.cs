using Bie.Business.Models;

namespace Bie.Business.Interfaces.Services;
public interface ISchedulingService : IService<Scheduling>
{
    Task<IEnumerable<Scheduling>> GetAllOpenByCompanyIdAsync(string companyId, DateTime initialDate, DateTime finalDate);
    Task<IEnumerable<TimeSpan>> GetAvailableTimesAsync(string companyId, string serviceSelected, DateOnly date);
}