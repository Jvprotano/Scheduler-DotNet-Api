using Agende.Business.Enums;
using Agende.Api.DTOs.Base;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Agende.Api.DTOs.Request;
public class CompanyRequestDto : BaseDto
{
    [Display(Name = "Name")]
    [Required(ErrorMessage = "Name is required")]
    public required string Name { get; set; }

    public required string SchedulingUrl { get; set; }

    [Display(Name = "CNPJ")]
    public string? Cnpj { get; set; }

    [JsonPropertyName("image")]
    public string? ImageBase64 { get; set; }

    public ScheduleStatusEnum ScheduleStatus { get; set; } = ScheduleStatusEnum.Closed;

    public List<ScheduleRequestDto> Schedule { get; set; } = [];
    public List<CompanyServiceOfferedRequestDto> ServicesOffered { get; set; } = [];
    public List<CompanyEmployeeRequestDto> Employees { get; set; } = [];
}