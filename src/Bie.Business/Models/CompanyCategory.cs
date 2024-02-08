using Bie.Business.Enums;
using Bie.Business.Models.Base;

using System.ComponentModel.DataAnnotations.Schema;

namespace Bie.Business.Models;
[Table("companies_categories")]
public class CompanyCategory : EntityBase
{
    public string CompanyId { get; set; } = string.Empty;
    public Company? Company { get; set; }

    public CategoryEnum CategoryId { get; set; }
}