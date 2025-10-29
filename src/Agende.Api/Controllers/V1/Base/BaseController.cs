using System.IdentityModel.Tokens.Jwt;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Agende.Api.DTOs.Response;
using Asp.Versioning;

namespace Agende.Api.Controllers.V1.Base;

[ApiVersion("1.0")]
[ApiController]
public abstract class BaseController : ControllerBase
{
    protected IActionResult SuccessResponse(object data, string message = "", HttpStatusCode status = HttpStatusCode.OK)
    {
        var response = new ApiResponse
        {
            Success = true,
            Data = data,
            Status = status,
            Message = message
        };

        return Ok(response);
    }
    protected IActionResult ErrorResponse(string error = "", HttpStatusCode status = HttpStatusCode.BadRequest)
    {
        var errorResponse = new ApiResponse
        {
            Success = false,
            Status = status,
            Message = error
        };

        return StatusCode((int)status, errorResponse);
    }

    protected Guid GetUserIdFromClaims()
        => new(User.Claims.First(c => c.Type == "userId").Value);

}