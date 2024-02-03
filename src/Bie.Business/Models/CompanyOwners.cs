using Bie.Business.Models.Base;

using System.ComponentModel.DataAnnotations.Schema;

namespace Bie.Business.Models;
[Table("companies_owners")]
public class CompanyOwners : EntityBase
{
    public string CompanyId { get; set; }
    public Company Company { get; set; }
    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
}