using Bie.Business.Enums;

namespace Bie.Api.DTOs.Base;
public class BaseViewModel
{
    public string id { get; set; }
    public StatusEnum? Status { get; set; }
}