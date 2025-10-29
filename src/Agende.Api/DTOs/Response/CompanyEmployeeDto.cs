using Agende.Api.DTOs.Base;

namespace Agende.Api.DTOs.Response;

public class CompanyEmployeeDto : BaseDto
{
    public Guid CompanyId { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string? UserImageUrl { get; set; }
    public bool IsOwner { get; set; }
}