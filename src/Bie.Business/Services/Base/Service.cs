using Bie.Business.Interfaces.Repositories.Base;
using Bie.Business.Interfaces.Services;
using Bie.Business.Models.Base;

namespace Bie.Business.Services.Base;
public class Service<T> : IService<T> where T : EntityBase
{
    private readonly IRepository<T> _repositoryBase;
    public Service(IRepository<T> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }
    public virtual async Task<IEnumerable<T>> GetAllAsync(bool active = true)
    {
        return await _repositoryBase.GetAllAsync(active);
    }
    public virtual IQueryable<T> GetAll(bool active = true)
    {
        return _repositoryBase.GetAll(active);
    }
    public virtual async Task<T> GetByIdAsync(Guid id, bool active = true)
    {
        return await _repositoryBase.GetByIdAsync(id, active);
    }
    public async Task<T> GetAsync(Guid id, bool active = true)
    {
        return await _repositoryBase.GetAsync(id, active);
    }
    public virtual async Task SaveAsync(T entity)
    {
        Validate(entity);
        await _repositoryBase.SaveAsync(entity);
    }
    public virtual void Validate(T entity)
    {
        if (entity == null)
            throw new Exception("Entity is null");

        if (entity.Id == default)
            throw new Exception("Id is invalid");
    }
}