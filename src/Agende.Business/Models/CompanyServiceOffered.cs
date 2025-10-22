using Agende.Business.Models.Base;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agende.Business.Models;
[Table("companies_services_offered")]
public class CompanyServiceOffered : EntityBase
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    [Required]
    public float Price { get; set; }
    [Required]
    public string CompanyId { get; set; } = string.Empty;
    public Company? Company { get; set; }
    public TimeOnly Duration { get; set; }
    public IList<Scheduling> Schedulings { get; set; } = [];
}