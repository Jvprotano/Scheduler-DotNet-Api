namespace Bie.Api.DTOs.Response;
public class ApiResponse
{
    public bool Success { get; set; }
    public object Data { get; set; } = new();
    public int Status { get; set; }
    public string Message { get; set; } = "";
}