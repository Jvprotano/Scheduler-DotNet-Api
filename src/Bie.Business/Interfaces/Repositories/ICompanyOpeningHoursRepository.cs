using Bie.Business.Models;

namespace Bie.Business.Interfaces.Repositories;
public interface ICompanyOpeningHoursRepository
{
    List<CompanyOpeningHours> GetByDayOfWeek(string companyId, DayOfWeek dayOfWeek);
}