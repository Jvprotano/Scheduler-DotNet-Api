using AutoMapper;

using Bie.Api.Controllers.V1.Base;
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
    public async Task<IActionResult> Get(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
            return this.ErrorResponse("User not found.");

        var model = _mapper.Map<UserResponseDto>(user);

        return SuccessResponse(model);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UserResponseDto user)
    {
        try
        {
            ApplicationUser applicationUser = _mapper.Map<ApplicationUser>(user);
            IdentityResult result = await _userService.UpdateAsync(applicationUser);

            if (!result.Succeeded)
                return BadRequest(new { errors = result.Errors });

            return SuccessResponse(data: new { }, status: System.Net.HttpStatusCode.NoContent);
        }
        catch (Exception ex)
        {
            return ErrorResponse(ex.Message);
        }
    }

}