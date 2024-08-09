namespace Bie.Business.Interfaces.Repositories.Base;
public interface IRepository<T>
{
    Task SaveAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync(bool active = true);
    Task<T> GetByIdAsync(string id, bool active = true);
    Task<T> GetAsync(string id, bool active = true);
    IQueryable<T> GetAll(bool active = true);
}