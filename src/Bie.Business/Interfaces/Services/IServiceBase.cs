using Bie.Business.Models.Base;

namespace Bie.Business.Interfaces.Services;
public interface IService<T> where T : EntityBase
{
    public Task SaveAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync(bool active = true);
    Task<T> GetByIdAsync(Guid id, bool active = true);
    Task<T> GetAsync(Guid id, bool active = true);
    IQueryable<T> GetAll(bool active = true);
}
