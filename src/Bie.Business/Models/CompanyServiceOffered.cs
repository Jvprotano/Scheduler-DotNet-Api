using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Bie.Business.Models.Base;

namespace Bie.Business.Models;
[Table("companies_services_offered")]
public class CompanyServiceOffered : EntityBase
{
    public CompanyServiceOffered(string name, float price, Guid companyId, 
                                TimeOnly duration, string? description = null)
    {
        Name = name;
        Description = description;
        Price = price;
        CompanyId = companyId;
        Duration = duration;
    }

    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
    [Required]
    public float Price { get; set; }
    [Required]
    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }
    public TimeOnly Duration { get; set; }
    public IList<Scheduling> Schedulings { get; set; } = [];
}