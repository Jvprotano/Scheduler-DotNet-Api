using System.ComponentModel.DataAnnotations;
using Bie.Business.Enums;

namespace Bie.Business.Models.Base;
public abstract class EntityBase
{
    public string Id { get; set; }
    [Required]
    public StatusEnum? Status { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime UpdatedAt { get; set; }
}