using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bie.Api.DTOs;
public class SchedulingViewModel
{
    public int CompanyId { get; set; }
    public int CustomerId { get; set; }
    public string? ServiceSelectedId { get; set; }
    public DateTime ScheduledDate { get; set; }
    public string? TimeSelected { get; set; }
}