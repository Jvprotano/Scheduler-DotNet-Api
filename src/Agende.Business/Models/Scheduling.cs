using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Agende.Business.Models.Base;

namespace Agende.Business.Models;

[Table("schedulings")]
public class Scheduling : EntityBase
{
    [Required]
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
    [Required]
    public Guid CustomerId { get; set; }
    public ApplicationUser? Customer { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }

    [Required]
    public Guid ServicesOfferedId { get; set; }
    public CompanyServiceOffered? ServiceOffered { get; set; }

    [Required]
    public Guid? EmployeeId { get; set; }
    public ApplicationUser? Employee { get; set; }
}