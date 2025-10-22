using Agende.Business.Models.Base;

using System.ComponentModel.DataAnnotations.Schema;

namespace Agende.Business.Models;
[Table("companies_employees")]
public class CompanyEmployee : EntityBase
{
    public string CompanyId { get; set; } = string.Empty;
    public Company? Company { get; set; }
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }
    public bool IsOwner { get; set; }
}