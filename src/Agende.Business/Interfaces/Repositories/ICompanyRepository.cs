using Agende.Business.Interfaces.Repositories.Base;
using Agende.Business.Models;

namespace Agende.Business.Interfaces.Repositories;

public interface ICompanyRepository : IRepository<Company>
{
    Task<IEnumerable<Company>> GetAllOpen();
    Task<IEnumerable<Company>> GetCompaniesByUserAsync(Guid userId);
    Task ReactiveAsync(Guid id);
    Task TemporaryDeleteAsync(Guid id);
    Task<Company> NewSaveAsync(Company entity);
}