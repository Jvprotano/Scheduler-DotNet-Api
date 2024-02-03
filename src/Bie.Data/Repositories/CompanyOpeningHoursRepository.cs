using Bie.Business.Interfaces.Repositories;
using Bie.Data.Context;
using Bie.Business.Models;
using Bie.Data.Repositories.Base;

namespace Bie.Data.Repositories;
public class CompanyOpeningHoursRepository : Repository<CompanyOpeningHours>, ICompanyOpeningHoursRepository
{
    public CompanyOpeningHoursRepository(ApplicationDbContext context)
    : base(context)
    {
    }
    public List<CompanyOpeningHours> GetAll(string companyId)
    {
        return DbSet.Where(c => c.CompanyId == companyId).ToList();
    }
    public List<CompanyOpeningHours> GetByDayOfWeek(string companyId, DayOfWeek dayOfWeek)
    {
        return DbSet
        .Where(c => c.CompanyId == companyId && c.DayOfWeek == dayOfWeek)
        .ToList();
    }
}