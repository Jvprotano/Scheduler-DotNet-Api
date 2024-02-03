using Bie.Business.Models.Base;

using System.ComponentModel.DataAnnotations.Schema;

namespace Bie.Business.Models;
[Table("schedulings")]
public class Scheduling : EntityBase
{
    public string CompanyId { get; set; }
    public Company Company { get; set; }
    public string CustomerId { get; set; }
    public ApplicationUser Customer { get; set; }
    public DateTime ScheduledDate { get; set; }
    public string ServicesOfferedId { get; set; }
    public CompanyServiceOffered ServiceOffered { get; set; }
}