using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Agende.Business.Enums;
using Agende.Business.Models.Base;

namespace Agende.Business.Models;

[Table("companies")]
public class Company : EntityBase
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Cnpj { get; set; }
    public string? ImageUrl { get; set; }
    [NotMapped]
    public string? ImageBase64 { get; set; }
    public DateTime? InactiveDate { get; set; }
    public string SchedulingUrl { get; set; } = string.Empty;
    public ScheduleStatusEnum ScheduleStatus { get; set; }

    public IList<CompanyEmployee> Employeers { get; set; } = [];
    public IList<CompanyServiceOffered>? ServicesOffered { get; set; }
    public IList<CompanyOpeningHours> OpeningHours { get; set; } = [];
    public IList<Scheduling>? Schedulings { get; set; }
}