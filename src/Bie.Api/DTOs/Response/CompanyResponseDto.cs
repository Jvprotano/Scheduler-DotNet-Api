using Bie.Business.Enums;
using Bie.Api.DTOs.Base;

using System.ComponentModel.DataAnnotations;

namespace Bie.Api.DTOs.Response;
public class CompanyResponseDto : BaseDto
{
    [Display(Name = "Name")]
    public string? Name { get; set; }
    [Display(Name = "Email")]
    [EmailAddress]
    public string? Email { get; set; }
    public string? Description { get; set; }
    [Display(Name = "CNPJ")]
    public string? Cnpj { get; set; }
    [Display(Name = "City")]
    public int? CityId { get; set; }
    public string? Address { get; set; }
    [Display(Name = "Number")]
    public string? AddressNumber { get; set; }
    public string? PostalCode { get; set; }
    [Display(Name = "Is not a physical location")]
    public bool IsVirtual { get; set; }
    public string? ImageUrl { get; set; }
    public ScheduleStatusEnum ScheduleStatus { get; set; }
}