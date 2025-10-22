using Agende.Business.Models;

namespace Agende.Business.Interfaces.Repositories;
public interface ICompanyOpeningHoursRepository
{
    List<CompanyOpeningHours> GetByDayOfWeek(string companyId, DayOfWeek dayOfWeek);
}