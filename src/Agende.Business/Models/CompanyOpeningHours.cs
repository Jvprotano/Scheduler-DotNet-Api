using System.ComponentModel.DataAnnotations.Schema;
using Agende.Business.Models.Base;

namespace Agende.Business.Models;

[Table("companies_opening_hours")]
public class CompanyOpeningHours : EntityBase
{
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly OpeningHour { get; set; }
    public TimeOnly ClosingHour { get; set; }
}