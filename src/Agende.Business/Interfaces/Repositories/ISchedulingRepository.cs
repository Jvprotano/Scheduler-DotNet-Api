using Agende.Business.Interfaces.Repositories.Base;
using Agende.Business.Models;

namespace Agende.Business.Interfaces.Repositories;
public interface ISchedulingRepository : IRepository<Scheduling>
{
    Task<IEnumerable<Scheduling>> GetAllByDateAsync(Guid companyId, DateOnly date, Guid? professionalId  = null);
    Task<IEnumerable<Scheduling>> GetAllOpenByCompanyIdAsync(Guid companyId, DateOnly initialDate, DateOnly finalDate);
}