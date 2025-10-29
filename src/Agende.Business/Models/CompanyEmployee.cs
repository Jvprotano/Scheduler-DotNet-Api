using Agende.Business.Models.Base;

using System.ComponentModel.DataAnnotations.Schema;

namespace Agende.Business.Models;

[Table("companies_employees")]
public class CompanyEmployee : EntityBase
{
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
    public Guid UserId { get; set; }
    public ApplicationUser? User { get; set; }
    public bool IsOwner { get; set; }
}