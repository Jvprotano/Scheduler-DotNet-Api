using Microsoft.EntityFrameworkCore;

using Bie.Business.Interfaces.Repositories;
using Bie.Data.Context;
using Bie.Business.Models;
using Bie.Data.Repositories.Base;

namespace Bie.Data.Repositories;
public class SchedulingRepository : Repository<Scheduling>, ISchedulingRepository
{
    public SchedulingRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Scheduling>> GetAllByDateAsync(string companyId, DateOnly date)
    {
        return await DbSet.Where(c => c.CompanyId == companyId &&
            c.ScheduledDate == date)
            .ToListAsync();
    }

    public async Task<IEnumerable<Scheduling>> GetAllOpenByCompanyIdAsync(string companyId, DateOnly initialDate, DateOnly finalDate)
    {
        return await this.DbSet
        .Include(c => c.ServiceOffered)
        .Include(c => c.Customer)
        .Where(c => c.CompanyId == companyId && c.ScheduledDate >= initialDate &&
                    c.ScheduledDate <= finalDate)
        .OrderBy(c => c.ScheduledDate)
        .ToListAsync();
    }
}