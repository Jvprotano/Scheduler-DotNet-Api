using Agende.Business.Models.Base;

namespace Agende.Business.Interfaces.Services;
public interface IService<T> where T : EntityBase
{
    public Task SaveAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync(bool active = true);
    Task<T> GetByIdAsync(string id, bool active = true);
    Task<T> GetAsync(string id, bool active = true);
    IQueryable<T> GetAll(bool active = true);
}
