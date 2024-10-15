using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Bie.Business.Enums;
using Bie.Business.Models.Base;

namespace Bie.Business.Models;
[Table("companies")]
public class Company : ProfileBase
{
    public Company() : base("", "")
    {
        Description = string.Empty;
        SchedulingUrl = string.Empty;
    }
    public Company(string name, string email, string schedulingUrl, string description, 
                    string? cnpj = null, bool isVirtual = false) : base(name, email)
    {
        Description = description;
        Cnpj = cnpj;
        IsVirtual = isVirtual;
        SchedulingUrl = schedulingUrl;
    }

    [Required]
    public string Description { get; private set; }
    public string? Cnpj { get; private set; }
    public bool IsVirtual { get; private set; }
    public string SchedulingUrl { get; private set; }
    public ScheduleStatusEnum ScheduleStatus { get; private set; }
    public IList<CompanyEmployee>? Employeers { get; private set; }
    public IList<CompanyCategory>? Categories { get; private set; }
    public IList<CompanyServiceOffered>? ServicesOffered { get; private set; }
    public virtual IList<CompanyOpeningHours>? OpeningHours { get; private set; }
    public void CloseSchedule()
    {
        ScheduleStatus = ScheduleStatusEnum.Closed;
    }
    public void OpenSchedule()
    {
        ScheduleStatus = ScheduleStatusEnum.Closed;
    }
    public override void Inactivate()
    {
        ScheduleStatus = ScheduleStatusEnum.Closed;
        base.Inactivate();
    }
    public override void TemporaryRemove()
    {
        ScheduleStatus = ScheduleStatusEnum.Closed;
        InactiveDate = DateTime.Now;
        base.TemporaryRemove();
    }
    public override void Reactive()
    {
        ScheduleStatus = ScheduleStatusEnum.Closed;
        InactiveDate = null;
        base.Reactive();
    }
}