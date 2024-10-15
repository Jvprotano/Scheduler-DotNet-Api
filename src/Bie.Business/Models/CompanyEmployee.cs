using System.ComponentModel.DataAnnotations.Schema;

using Bie.Business.Models.Base;

namespace Bie.Business.Models;
[Table("companies_employees")]
public class CompanyEmployee : EntityBase
{
    public CompanyEmployee(Guid companyId, Guid userId, bool isOwner = false) 
        : base()
    {
        CompanyId = companyId;
        UserId = userId;
        IsOwner = isOwner;
    }

    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
    public Guid UserId { get; set; }
    public ApplicationUser? User { get; set; }
    public bool IsOwner { get; set; }
}