using System.Security.Claims;
using AutoMapper;

using Bie.Api.Controllers.V1.Base;
using Bie.Api.DTOs.Request;
using Bie.Api.DTOs.Response;
using Bie.Business.Interfaces.Services;
using Bie.Business.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bie.Api.Controllers.V1;

[Route("api/v{version:apiVersion}/[controller]")]
[Authorize]
public class UserController : BaseController
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UserController(UserManager<ApplicationUser> userManager, IMapper mapper, IUserService userService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _userService = userService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(UserResponseDto), 200)]
    public async Task<IActionResult> Get(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            return this.ErrorResponse("User not found.");

        var model = _mapper.Map<UserResponseDto>(user);

        return SuccessResponse(model);
    }
    [HttpGet]
    [ProducesResponseType(typeof(UserResponseDto), 200)]
    public async Task<IActionResult> Profile()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
            return this.ErrorResponse("User not found.");

        var user = await _userManager.FindByIdAsync(userId);

        var model = _mapper.Map<UserResponseDto>(user);

        return SuccessResponse(model);
    }

    [HttpPut]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Put([FromBody] UserRequestDto user)
    {
        try
        {
            if (user == null || user.Id == default)
                throw new ArgumentException("User must be informed.");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != user.Id)
                return ErrorResponse("User not authorized.");


            ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(user);
            IdentityResult result = await _userService.UpdateAsync(applicationUser);

            if (!result.Succeeded)
                return ErrorResponse(result.Errors.ToString() ?? "Unknow error");

            return SuccessResponse(data: new { }, status: System.Net.HttpStatusCode.NoContent);
        }
        catch (Exception ex)
        {
            return ErrorResponse(ex.Message);
        }
    }

}