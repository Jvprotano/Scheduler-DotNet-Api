using System.ComponentModel.DataAnnotations.Schema;

using Bie.Business.Models.Base;

namespace Bie.Business.Models;
[Table("companies_opening_hours")]
public class CompanyOpeningHours : EntityBase
{
    public CompanyOpeningHours(Guid companyId, DayOfWeek dayOfWeek, TimeOnly openingHour, TimeOnly closingHour)
    {
        CompanyId = companyId;
        DayOfWeek = dayOfWeek;
        OpeningHour = openingHour;
        ClosingHour = closingHour;
    }

    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly OpeningHour { get; set; }
    public TimeOnly ClosingHour { get; set; }
}