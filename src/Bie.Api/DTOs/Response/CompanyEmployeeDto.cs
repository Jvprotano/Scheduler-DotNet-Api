using Bie.Api.DTOs.Base;

namespace Bie.Api.DTOs.Response;
public class CompanyEmployeeDto : BaseDto
{
    public Guid CompanyId { get; set; }
    public Guid userId { get; set; }
    public string? UserName {get; set; }
    public string? UserImageUrl { get; set; }
    public bool IsOwner { get; set; }
}