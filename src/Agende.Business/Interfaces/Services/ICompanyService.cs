using Agende.Business.Models;

namespace Agende.Business.Interfaces.Services;
public interface ICompanyService : IService<Company>
{
    Task<IEnumerable<Company>> GetAllOpen();
    Task<IEnumerable<Company>> GetCompaniesByUserAsync(string userId);
    Task ReactiveAsync(string id);
    Task TemporaryDeleteAsync(string id);
}