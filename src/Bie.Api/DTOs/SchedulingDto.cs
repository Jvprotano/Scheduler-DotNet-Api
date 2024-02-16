namespace Bie.Api.DTOs.Request;
public class SchedulingRequestDto
{
    public int CompanyId { get; set; }
    public int CustomerId { get; set; }
    public string ServiceId { get; set; } = string.Empty;
    public DateOnly ScheduledDate { get; set; }
    public TimeOnly TimeSelected { get; set; }
}