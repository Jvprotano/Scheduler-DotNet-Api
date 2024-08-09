using System.Net;

namespace Bie.Api.DTOs.Response;
public class ApiResponse
{
    public bool Success { get; set; }
    public object Data { get; set; } = new();
    public HttpStatusCode Status { get; set; }
    public string Message { get; set; } = "";
}
public class LoginResponse
{
    public string Bearer { get; set; } = "";
    public string UserName { get; set; } = "";
}