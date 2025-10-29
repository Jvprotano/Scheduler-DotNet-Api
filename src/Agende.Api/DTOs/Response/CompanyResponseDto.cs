using Agende.Business.Enums;
using Agende.Api.DTOs.Base;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Agende.Api.DTOs.Response;
public class CompanyResponseDto : BaseDto
{
    [Display(Name = "Name")]
    public string Name { get; set; } = string.Empty;
    [Display(Name = "Email")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    [Display(Name = "CNPJ")]
    public string Cnpj { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    [Display(Name = "Number")]
    public string AddressNumber { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    [Display(Name = "Is not a physical location")]
    public bool IsVirtual { get; set; }
    [JsonPropertyName("image")]
    public string ImageUrl { get; set; } = string.Empty;
    public ScheduleStatusEnum ScheduleStatus { get; set; }
    public IList<CompanyServiceOfferedDto>? ServicesOffered { get; set; }
    public IList<CompanyEmployeeDto>? Employeers { get; set; }
}