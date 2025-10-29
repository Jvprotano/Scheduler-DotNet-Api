using Agende.Business.Models.Base;

namespace Agende.Business.Models;

public class EmployeeServiceLink : EntityBase
{
    public Guid EmployeeId { get; set; }
    public Guid ServiceId { get; set; }
    public ApplicationUser Employee { get; set; } = new();
    public CompanyServiceOffered Service { get; set; } = new();
}