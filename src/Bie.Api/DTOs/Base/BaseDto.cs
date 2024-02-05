using Bie.Business.Enums;

namespace Bie.Api.DTOs.Base;
public class BaseDto
{
    public string? Id { get; set; }
    public StatusEnum? Status { get; set; }
}