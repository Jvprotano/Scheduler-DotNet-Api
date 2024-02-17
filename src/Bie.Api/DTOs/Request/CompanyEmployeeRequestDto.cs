namespace Bie.Api.DTOs.Request;
public class CompanyEmployeeRequestDto
{
    public string CompanyId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public bool IsOwner { get; set; }
}