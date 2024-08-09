using System.ComponentModel.DataAnnotations;
using Bie.Api.DTOs.Base;

namespace Bie.Api.DTOs.Request;
public class CompanyServiceOfferedRequestDto : BaseDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public float Price { get; set; }
    [Required]
    public string CompanyId { get; set; } = string.Empty;
    public TimeOnly Duration { get; set; }
}