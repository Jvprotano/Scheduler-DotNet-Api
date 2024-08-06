namespace Bie.Api.DTOs.Response;
public class CompanyServiceOfferedDto
{
    public string Name { get; set; } = string.Empty;
    public float Price { get; set; }
    // public string CompanyId { get; set; } = string.Empty;
    public TimeOnly Duration { get; set; }
}