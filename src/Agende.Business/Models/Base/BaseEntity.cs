using System.ComponentModel.DataAnnotations;
using Agende.Business.Enums;

namespace Agende.Business.Models.Base;

public abstract class EntityBase
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public StatusEnum? Status { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime UpdatedAt { get; set; }
}