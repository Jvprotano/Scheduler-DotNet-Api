using Asp.Versioning;

using AutoMapper;

using Bie.Api.Controllers.V1.Base;
using Bie.Api.DTOs;
using Bie.Business.Interfaces.Services;
using Bie.Business.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bie.Api.Controllers.V1;

[ApiVersion(1.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public class AccountController : BaseController
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IMapper _mappper;
    private readonly IAuthService _authService;

    public AccountController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IMapper mappper,
        IAuthService authService) : base()
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mappper = mappper;
        _authService = authService;
    }
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
    {
        if (await _userManager.FindByEmailAsync(model.Email ?? "") != null)
            ModelState.AddModelError(string.Empty, "Email already exists");
        if (model.Password != model.ConfirmPassword)
            ModelState.AddModelError(string.Empty, "Passwords don't match");

        var user = _mappper.Map<ApplicationUser>(model);
        var result = await _userManager.CreateAsync(user, model.Password ?? "");

        if (result.Succeeded)
            return Ok(result);

        return BadRequest(result.Errors);
    }
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginViewModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.EmailOrUserName ?? "");

        var result = await _signInManager.PasswordSignInAsync(user?.UserName ?? model.EmailOrUserName ?? "", model.Password ?? "", model.RememberMe, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            if (user != null)
            {
                var token = _authService.GenerateToken(user);
                return Ok(new { bearer = token });
            }
        }
        return BadRequest("User not found or password is incorrect");
    }
}