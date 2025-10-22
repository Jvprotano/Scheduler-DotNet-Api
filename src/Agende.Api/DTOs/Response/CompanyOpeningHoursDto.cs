namespace Agende.Api.DTOs.Response;
public class CompanyOpeningHoursDto
{
    // public string CompanyId { get; set; } = string.Empty;
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly OpeningHour { get; set; }
    public TimeOnly ClosingHour { get; set; }
}