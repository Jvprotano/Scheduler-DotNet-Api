using Bie.Business.Interfaces.Repositories.Base;
using Bie.Business.Models;

namespace Bie.Business.Interfaces.Repositories;
public interface ICompanyRepository : IRepository<Company>
{
    Task<IEnumerable<Company>> GetAllOpen();
    Task<IEnumerable<Company>> GetCompaniesByUserAsync(Guid userId);
    Task ReactiveAsync(Guid id);
    Task TemporaryDeleteAsync(Guid id);
}