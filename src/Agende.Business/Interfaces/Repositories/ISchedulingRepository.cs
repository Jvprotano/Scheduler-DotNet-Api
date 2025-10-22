using Agende.Business.Interfaces.Repositories.Base;
using Agende.Business.Models;

namespace Agende.Business.Interfaces.Repositories;
public interface ISchedulingRepository : IRepository<Scheduling>
{
    Task<IEnumerable<Scheduling>> GetAllByDateAsync(string companyId, DateOnly date, string? professionalId = null);
    Task<IEnumerable<Scheduling>> GetAllOpenByCompanyIdAsync(string companyId, DateOnly initialDate, DateOnly finalDate);
}