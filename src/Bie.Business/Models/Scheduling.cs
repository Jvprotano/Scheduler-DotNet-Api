using Bie.Business.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bie.Business.Models;
[Table("schedulings")]
public class Scheduling : EntityBase
{
    [Required]
    public string CompanyId { get; set; } = string.Empty;
    public Company? Company { get; set; }
    [Required]
    public string CustomerId { get; set; } = string.Empty;
    public ApplicationUser? Customer { get; set; }
    public DateOnly ScheduledDate { get; set; }
    public TimeOnly ScheduledTime { get; set; }

    [Required]
    public string ServicesOfferedId { get; set; } = string.Empty;
    public CompanyServiceOffered? ServiceOffered { get; set; }
}