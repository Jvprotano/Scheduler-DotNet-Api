using System.Data.Common;
using AutoMapper;

using Bie.Api.Controllers.V1.Base;
using Bie.Api.DTOs.Request;
using Bie.Business.Interfaces.Services;
using Bie.Business.Models;

using Microsoft.AspNetCore.Mvc;

namespace Bie.Api.Controllers.V1;

[Route("api/v{version:apiVersion}")]
public class AccountController : BaseController
{
    private readonly IMapper _mappper;
    private readonly IAuthService _authService;

    public AccountController(
        IMapper mappper,
        IAuthService authService) : base()
    {
        _mappper = mappper;
        _authService = authService;
    }
    [HttpPost]
    [Route("login")]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(object))]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        ApplicationUser? user = await _authService.LoginAsync(model.EmailOrPhone, model.Password, model.RememberMe);

        if (user != null)
        {
            var token = _authService.GenerateToken(user);
            return SuccessResponse(data: new { Bearer = token, userName = user.UserName });
        }
        return ErrorResponse("User not found or password is incorrect");
    }
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
        if (await _authService.FindByEmailAsync(model.Email ?? "") != null)
            ModelState.AddModelError(string.Empty, "Email already exists");
        if (await _authService.FindByPhoneAsync(model.Phone ?? "") != null)
            ModelState.AddModelError(string.Empty, "Phone already exists");
        if (model.Password != model.ConfirmPassword)
            ModelState.AddModelError(string.Empty, "Passwords don't match");

        if (ModelState.IsValid)
        {
            try
            {
                var appUser = _mappper.Map<ApplicationUser>(model);
                var user = await _authService.CreateAsync(appUser, model.Password);

                if (user != null)
                    SuccessResponse(new object());

                ErrorResponse("User not created");
            }
            catch (DbException ex)
            {
                ErrorResponse(ex.Message, System.Net.HttpStatusCode.InternalServerError);
            }
            catch (Exception ex)
            {
                ErrorResponse(ex.Message);
            }
        }
        return ErrorResponse();
    }
}