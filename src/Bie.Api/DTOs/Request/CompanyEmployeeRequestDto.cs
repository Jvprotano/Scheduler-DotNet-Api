namespace Bie.Api.DTOs.Request;
public class CompanyEmployeeRequestDto
{
    public Guid CompanyId { get; set; }
    public Guid userId { get; set; }
    public bool IsOwner { get; set; }
}