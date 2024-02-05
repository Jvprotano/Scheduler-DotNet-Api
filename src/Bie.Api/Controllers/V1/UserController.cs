using AutoMapper;

using Bie.Api.Controllers.V1.Base;
using Bie.Api.DTOs.Response;
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

    public UserController(UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
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
    public async Task<IActionResult> Put()
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            return ErrorResponse(ex.Message);
        }
    }

}