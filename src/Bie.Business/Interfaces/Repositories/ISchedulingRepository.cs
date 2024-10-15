using Bie.Business.Interfaces.Repositories.Base;
using Bie.Business.Models;

namespace Bie.Business.Interfaces.Repositories;
public interface ISchedulingRepository : IRepository<Scheduling>
{
    Task<IEnumerable<Scheduling>> GetAllByDateAsync(Guid companyId, DateOnly date, Guid? professionalId = null);
    Task<IEnumerable<Scheduling>> GetAllOpenByCompanyIdAsync(Guid companyId, DateOnly initialDate, DateOnly finalDate);
}