using Bie.Api.DTOs.Base;

namespace Bie.Api.DTOs.Response;
public class CompanyEmployeeDto : BaseDto
{
    public string CompanyId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string UserName {get; set; } = string.Empty;
    public bool IsOwner { get; set; }
}