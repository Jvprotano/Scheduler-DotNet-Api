using Agende.Business.Models;

namespace Agende.Business.Interfaces.Repositories;
public interface ICompanyOpeningHoursRepository
{
    List<CompanyOpeningHours> GetByDayOfWeek(Guid companyId, DayOfWeek dayOfWeek);
}