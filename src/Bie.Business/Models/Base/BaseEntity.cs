using System.ComponentModel.DataAnnotations;

using Bie.Business.Enums;

namespace Bie.Business.Models.Base;
public abstract class EntityBase
{
    protected EntityBase(StatusEnum? status = StatusEnum.Active)
    {
        Id = Guid.NewGuid();
        Status = status;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    [Required]
    public Guid Id { get; }
    [Required]
    public StatusEnum? Status { get; protected set; }
    [Required]
    public DateTime CreatedAt { get; private set; }
    [Required]
    public DateTime UpdatedAt { get; private set; }

    public void Remove()
    {
        Status = StatusEnum.Removed;
    }
    public virtual void Reactive()
    {
        Status = StatusEnum.Active;
    }
    public virtual void TemporaryRemove()
    {
        Status = StatusEnum.TemporaryRemoved;
    }
}