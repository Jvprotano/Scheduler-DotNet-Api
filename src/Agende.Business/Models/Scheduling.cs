using Agende.Business.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agende.Business.Models;
[Table("schedulings")]
public class Scheduling : EntityBase
{
    [Required]
    public string CompanyId { get; set; } = string.Empty;
    public Company? Company { get; set; }
    [Required]
    public string CustomerId { get; set; } = string.Empty;
    public ApplicationUser? Customer { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }

    [Required]
    public string ServicesOfferedId { get; set; } = string.Empty;
    public CompanyServiceOffered? ServiceOffered { get; set; }

    [Required]
    public string? EmployeeId { get; set; }
    public ApplicationUser? Employee { get; set; }
}