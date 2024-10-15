using System.ComponentModel.DataAnnotations.Schema;

using Bie.Business.Enums;
using Bie.Business.Models.Base;

namespace Bie.Business.Models;
[Table("companies_categories")]
[NotMapped]
public class CompanyCategory : EntityBase
{
    public CompanyCategory(Guid companyId)
    {
        CompanyId = companyId;
    }

    public Guid CompanyId { get; private set; }
    public Company? Company { get; set; }
    public CategoryEnum CategoryId { get; private set; }
}