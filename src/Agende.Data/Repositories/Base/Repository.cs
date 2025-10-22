using System.Data.Common;
using Agende.Business.Interfaces.Repositories.Base;
using Agende.Business.Models.Base;
using Agende.Data.Context;

using Microsoft.EntityFrameworkCore;

namespace Agende.Data.Repositories.Base;
public class Repository<T> : IRepository<T> where T : EntityBase
{
    private readonly DbSet<T> _dbSet;
    private ApplicationDbContext _context;
    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public DbSet<T> DbSet { get => _dbSet; }
    public virtual async Task<IEnumerable<T>> GetAllAsync(bool active = true)
    {
        try
        {
            var query = DbSet.AsNoTracking();

            if (!active)
                query = query.IgnoreQueryFilters();

            return await query.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public virtual IQueryable<T> GetAll(bool active = true)
    {
        try
        {
            var query = DbSet.AsNoTracking();

            if (!active)
                query = query.IgnoreQueryFilters();

            return query;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public virtual async Task<T> GetByIdAsync(string id, bool active = true)
    {
        try
        {
            var query = DbSet.AsNoTracking();

            if (!active)
                query = query.IgnoreQueryFilters();

            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public virtual async Task SaveAsync(T entity)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                await DbSet.AddAsync(entity);
            }
            else
            {
                _context.Entry(entity).State = EntityState.Modified;
                BeforeUpdateChanges(entity);
            }
            await _context.SaveChangesAsync();
        }
        catch (DbException)
        {
            throw new Exception("Error on save entity");
        }
        catch (Exception)
        {
            throw new Exception("Unknown error on save entity");
        }
    }
    public virtual async Task TemporaryDeleteAsync(T entity)
    {
        try
        {
            entity.Status = Agende.Business.Enums.StatusEnum.TemporaryRemoved;
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public virtual async Task DeleteAsync(T entity)
    {
        try
        {
            entity.Status = Agende.Business.Enums.StatusEnum.Removed;
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<T> GetAsync(string id, bool active = true)
    {
        var query = DbSet.AsNoTracking()
            .Where(e => e.Id == id);

        if (!active)
            query = query.IgnoreQueryFilters();

        return await query.FirstOrDefaultAsync();
    }
    public virtual void UpdateCollection<U>(IEnumerable<U> collection)
    {
        if (collection == null)
            return;
        foreach (var entity in collection)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
    public virtual void BeforeUpdateChanges(T entity)
    {
    }

}