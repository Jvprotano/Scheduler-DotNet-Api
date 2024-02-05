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

    protected IActionResult SuccessResponse(object data, string message = "")
    {
        var response = new ApiResponse
        {
            Success = true,
            Data = data,
            Status = (int)HttpStatusCode.OK,
            Message = message
        };

        return Ok(response);
    }
    protected IActionResult ErrorResponse(string message = "")
    {
        var error = new ApiResponse
        {
            Success = false,
            Status = (int)HttpStatusCode.BadRequest,
            Message = message
        };

        return BadRequest(error);
    }

}