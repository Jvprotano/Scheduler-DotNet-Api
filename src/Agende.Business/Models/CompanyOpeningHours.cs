using Agende.Business.Models.Base;

using System.ComponentModel.DataAnnotations.Schema;

namespace Agende.Business.Models;
[Table("companies_opening_hours")]
public class CompanyOpeningHours : EntityBase
{
    public string CompanyId { get; set; } = string.Empty;
    public Company? Company { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly OpeningHour { get; set; }
    public TimeOnly ClosingHour { get; set; }
}