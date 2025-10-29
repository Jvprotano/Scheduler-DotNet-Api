using Agende.Business.Models;

namespace Agende.Business.Interfaces.Services;

public interface ICompanyService : IService<Company>
{
    Task<IEnumerable<Company>> GetCompaniesByUserAsync(Guid userId);
    Task ReactiveAsync(Guid id);
    Task TemporaryDeleteAsync(Guid id);

    Task<Company> CreateCompanyAsync(Company entity, Guid userId);
}