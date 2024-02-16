using Bie.Business.Models.Base;

using System.ComponentModel.DataAnnotations.Schema;

namespace Bie.Business.Models;
[Table("companies_employeeers")]
public class CompanyEmployeer : EntityBase
{
    public string CompanyId { get; set; } = string.Empty;
    public Company? Company { get; set; }
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }
    public bool IsOwner { get; set; }
}