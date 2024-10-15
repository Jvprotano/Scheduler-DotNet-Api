using Bie.Business.Models.Base;

namespace Bie.Business.Models;
public class EmployeeService : EntityBase
{
    public EmployeeService(Guid employeeId, Guid serviceId) : base()
    {
        EmployeeId = employeeId;
        ServiceId = serviceId;
    }
    public Guid EmployeeId { get; set; }
    public Guid ServiceId { get; set; }
    public virtual ApplicationUser? Employee { get; set; }
    public virtual CompanyServiceOffered? Service { get; set; }
}