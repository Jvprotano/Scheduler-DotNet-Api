namespace Agende.Api.DTOs.Request;
public class SchedulingRequestDto
{
    public string? CompanyId { get; set; }
    public string? CustomerId { get; set; }
    public Guid? ProfessionalId  { get; set; }
    public string ServiceId { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public string Time { get; set; } = TimeOnly.MinValue.ToString();
}