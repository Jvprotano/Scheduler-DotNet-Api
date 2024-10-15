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

    public async Task<IEnumerable<Scheduling>> GetAllByDateAsync(Guid companyId, DateOnly date, Guid? professionalId = null)
    {
        var query = DbSet.Where(c => c.CompanyId == companyId &&
            c.Date == date);

        if (professionalId != default)
            query = query.Where(c => c.EmployeeId == professionalId);

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<Scheduling>> GetAllOpenByCompanyIdAsync(Guid companyId, DateOnly initialDate, DateOnly finalDate)
    {
        return await this.DbSet
        .Include(c => c.ServiceOffered)
        .Include(c => c.Customer)
        .Where(c => c.CompanyId == companyId && c.Date >= initialDate &&
                    c.Date <= finalDate)
        .OrderBy(c => c.Date)
        .ToListAsync();
    }
}