using System.ComponentModel.DataAnnotations;
using Agende.Api.DTOs.Base;

namespace Agende.Api.DTOs.Request;
public class CompanyServiceOfferedRequestDto : BaseDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public float Price { get; set; }
    [Required]
    public Guid CompanyId { get; set; }
    public TimeOnly Duration { get; set; }
}