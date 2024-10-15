using Bie.Business.Models;

namespace Bie.Business.Interfaces.Services;
public interface ICompanyService : IService<Company>
{
    Task<IEnumerable<Company>> GetAllOpen();
    Task<IEnumerable<Company>> GetCompaniesByUserAsync(Guid userId);
    Task ReactiveAsync(Guid id);
    Task TemporaryDeleteAsync(Guid id);
}