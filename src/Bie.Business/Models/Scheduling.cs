using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Bie.Business.Models.Base;

namespace Bie.Business.Models;
[Table("schedulings")]
public class Scheduling : EntityBase
{
    public Scheduling(Guid companyId, Guid customerId, DateOnly date,
                    TimeOnly time, Guid servicesOfferedId, Guid? employeeId)
                    : base()
    {
        CompanyId = companyId;
        CustomerId = customerId;
        Date = date;
        Time = time;
        ServicesOfferedId = servicesOfferedId;
        EmployeeId = employeeId;
    }

    [Required]
    public Guid CompanyId { get; private set; }
    public Company? Company { get; private set; }
    [Required]
    public Guid CustomerId { get; private set; }
    public ApplicationUser? Customer { get; private set; }
    public DateOnly Date { get; private set; }
    public TimeOnly Time { get; private set; }

    [Required]
    public Guid ServicesOfferedId { get; private set; }
    public CompanyServiceOffered? ServiceOffered { get; private set; }

    [Required]
    public Guid? EmployeeId { get; private set; }
    public ApplicationUser? Employee { get; private set; }
}