using System.ComponentModel.DataAnnotations.Schema;
using Agende.Business.Models.Base;

namespace Agende.Business.Models;
[Table("cities")]
public class City : EntityBase
{
    public string? Name { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
}