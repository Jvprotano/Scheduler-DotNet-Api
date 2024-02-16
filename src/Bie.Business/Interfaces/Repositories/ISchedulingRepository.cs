using Bie.Business.Interfaces.Repositories.Base;
using Bie.Business.Models;

namespace Bie.Business.Interfaces.Repositories;
public interface ISchedulingRepository : IRepository<Scheduling>
{
    Task<IEnumerable<Scheduling>> GetAllByDateAsync(string companyId, DateOnly date);
    Task<IEnumerable<Scheduling>> GetAllOpenByCompanyIdAsync(string companyId, DateOnly initialDate, DateOnly finalDate);
}