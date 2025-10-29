namespace Agende.Api.DTOs.Request;

public class CompanyEmployeeRequestDto
{
    public Guid CompanyId { get; set; }
    public Guid UserId { get; set; }
    public bool IsOwner { get; set; }
}