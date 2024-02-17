using Bie.Api.DTOs.Base;

namespace Bie.Api.DTOs.Request;
public class CompanyOpeningHoursRequestDto : BaseDto
{
    public string CompanyId { get; set; } = string.Empty;
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly OpeningHour { get; set; }
    public TimeOnly ClosingHour { get; set; }
}