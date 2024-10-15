using Bie.Business.Models;

namespace Bie.Business.Interfaces.Services;
public interface ISchedulingService : IService<Scheduling>
{
    Task<IEnumerable<Scheduling>> GetAllOpenByCompanyIdAsync(Guid companyId, DateOnly initialDate, DateOnly finalDate);
    Task<IEnumerable<string>> GetAvailableTimesAsync(Guid companyId, Guid serviceSelected, DateOnly date, Guid? professionalId = null);
}