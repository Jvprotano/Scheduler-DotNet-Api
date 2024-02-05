namespace Bie.Api.DTOs.Request;
public class SchedulingRequestDto
{
    public int CompanyId { get; set; }
    public int CustomerId { get; set; }
    public string? ServiceSelectedId { get; set; }
    public DateTime ScheduledDate { get; set; }
    public string? TimeSelected { get; set; }
}