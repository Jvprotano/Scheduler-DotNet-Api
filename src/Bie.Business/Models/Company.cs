using Bie.Business.Enums;
using Bie.Business.Models.Base;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bie.Business.Models;
[Table("companies")]
public class Company : ProfileBase
{
    [Required]
    public string Description { get; set; } = string.Empty;
    public string? Cnpj { get; set; }
    public bool IsVirtual { get; set; }
    public DateTime? InactiveDate { get; set; }
    public ScheduleStatusEnum ScheduleStatus { get; set; }
    public IList<CompanyEmployeer> Employeers { get; set; } = [];
    public IList<CompanyCategory> Categories { get; set; } = [];
    public IList<CompanyServiceOffered> ServicesOffered { get; set; } = [];
    public virtual IList<CompanyOpeningHours> OpeningHours { get; set; } = [];
}