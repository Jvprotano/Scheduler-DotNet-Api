using Agende.Business.Interfaces.Repositories.Base;
using Agende.Business.Models;

namespace Agende.Business.Interfaces.Repositories;
public interface ICompanyRepository : IRepository<Company>
{
    Task<IEnumerable<Company>> GetAllOpen();
    Task<IEnumerable<Company>> GetCompaniesByUserAsync(string userId);
    Task ReactiveAsync(string id);
    Task TemporaryDeleteAsync(string id);
}