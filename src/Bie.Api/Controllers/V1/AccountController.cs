using System.Data.Common;
using AutoMapper;

using Bie.Api.Controllers.V1.Base;
using Bie.Api.DTOs.Request;
using Bie.Api.DTOs.Response;
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
    [ProducesResponseType(typeof(ApiResponse), 400)]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]

    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        ApplicationUser? user = await _authService.LoginAsync(model.EmailOrPhone, model.Password, model.RememberMe);

        if (user != null)
        {
            var token = _authService.GenerateToken(user);
            return SuccessResponse(new LoginResponse() { Bearer = token, UserName = user.UserName ?? user.Email ?? "" });
        }
        return ErrorResponse("User not found or password is incorrect");
    }
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
        string[] errors = new string[] { };

        if (model.Password != model.ConfirmPassword)
            errors.Append("Passwords don't match");
        if (await _authService.FindByEmailAsync(model.Email ?? "") != null)
            errors.Append("Email already exists");
        if (await _authService.FindByPhoneAsync(model.Phone ?? "") != null)
            errors.Append("Phone already exists");

        if (!errors.Any())
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
        return ErrorResponse(errors.ToString() ?? "Unknow error.");
    }
}