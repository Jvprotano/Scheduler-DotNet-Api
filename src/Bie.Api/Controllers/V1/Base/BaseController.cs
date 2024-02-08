using Asp.Versioning;

using Bie.Api.DTOs.Response;

using Microsoft.AspNetCore.Mvc;

using System.Net;

namespace Bie.Api.Controllers.V1.Base;

[ApiVersion("1.0")]
[ApiController]
public abstract class BaseController : ControllerBase
{
    public BaseController()
    {

    }

    protected IActionResult SuccessResponse(object data, string message = "", HttpStatusCode status = HttpStatusCode.OK)
    {
        var response = new ApiResponse
        {
            Success = true,
            Data = data,
            Status = (int)status,
            Message = message
        };

        return Ok(response);
    }
    protected IActionResult ErrorResponse(string message = "", HttpStatusCode status = HttpStatusCode.BadRequest)
    {
        var error = new ApiResponse
        {
            Success = false,
            Status = (int)status,
            Message = message
        };

        return StatusCode((int)status, error);
    }
}