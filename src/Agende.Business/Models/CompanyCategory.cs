using Agende.Business.Enums;
using Agende.Business.Models.Base;

using System.ComponentModel.DataAnnotations.Schema;

namespace Agende.Business.Models;
[Table("companies_categories")]
public class CompanyCategory : EntityBase
{
    public string CompanyId { get; set; } = string.Empty;
    public Company? Company { get; set; }

    public CategoryEnum CategoryId { get; set; }
}