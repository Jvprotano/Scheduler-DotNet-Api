using AutoMapper;

using Bie.Api.Controllers.Base;
using Bie.Api.DTOs;
using Bie.Business.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bie.Api.Controllers;

[Route("[controller]/[action]")]
public class AccountController : BaseController
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IMapper _mappper;

    public AccountController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IMapper mappper) : base()
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mappper = mappper;
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (await _userManager.FindByEmailAsync(model.Email ?? "") != null)
            ModelState.AddModelError(string.Empty, "Email already exists");
        if (model.Password != model.ConfirmPassword)
            ModelState.AddModelError(string.Empty, "Passwords don't match");

        var user = _mappper.Map<ApplicationUser>(model);
        var result = await _userManager.CreateAsync(user, model.Password ?? "");

        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.EmailOrUserName ?? "");

        var result = await _signInManager.PasswordSignInAsync(user.UserName ?? model.EmailOrUserName, model.Password ?? "", model.RememberMe, lockoutOnFailure: false);

        if (result.Succeeded)
            return Ok(result);

        return NotFound("User not found or password is incorrect");
    }
}