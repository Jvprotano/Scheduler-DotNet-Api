using Agende.Api.DTOs.Base;

namespace Agende.Api.DTOs.Response;
public class CompanyServiceOfferedDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public float Price { get; set; }
    public TimeOnly Duration { get; set; }
}