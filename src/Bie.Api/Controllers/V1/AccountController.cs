using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using AutoMapper;

using Bie.Api.Controllers.V1.Base;
using Bie.Api.DTOs.Request;
using Bie.Api.DTOs.Response;
using Bie.Business.Interfaces.Services;
using Bie.Business.Models;
using FluentValidation.Results;

using Microsoft.AspNetCore.Mvc;

namespace Bie.Api.Controllers.V1;

[Route("api/v{version:apiVersion}")]
public class AccountController : BaseController
{
    private readonly IMapper _mappper;
    private readonly IAuthService _authService;
    private readonly ILogger<AccountController> _logger;

    public AccountController(
        IMapper mappper,
        IAuthService authService,
        ILogger<AccountController> logger) : base()
    {
        _mappper = mappper;
        _authService = authService;
        _logger = logger;

    }
    [HttpPost]
    [Route("login")]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]

    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        try
        {
            _logger.LogInformation("Login attempt for {EmailOrPhone}", model.EmailOrPhone);

            ApplicationUser? user = await _authService.LoginAsync(model.EmailOrPhone, model.Password, model.RememberMe);

            if (user == null)
            {
                _logger.LogWarning("Login failed for {EmailOrPhone}", model.EmailOrPhone);
                return ErrorResponse("User not found or password is incorrect");
            }

            var token = _authService.GenerateToken(user);

            _logger.LogInformation("Login successful for {EmailOrPhone}", model.EmailOrPhone);
            return SuccessResponse(new LoginResponse() { Bearer = token, UserName = user.UserName ?? user.Email ?? "" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during login for {EmailOrPhone}", model.EmailOrPhone);
            return ErrorResponse("An error occurred while processing your request.");
        }
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
        try
        {
            FluentValidation.Results.ValidationResult validationResult = new RegisterDtoValidator().Validate(model);

            if (!validationResult.IsValid)
                return ErrorResponse(validationResult.ToString());

            var appUser = _mappper.Map<ApplicationUser>(model);
            var user = await _authService.CreateAsync(appUser, model.Password);

            if (user != null)
            {
                var userResponse = new UserResponseDto()
                {
                    Id = user.Id,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email
                };

                _logger.LogInformation("Created user: " + userResponse.Email);
                return SuccessResponse(userResponse);
            }

            return ErrorResponse("User not created");
        }
        catch (DbException ex)
        {
            _logger.LogTrace(ex.StackTrace);
            return ErrorResponse(ex.Message, System.Net.HttpStatusCode.InternalServerError);
        }
        catch (Exception ex)
        {
            _logger.LogTrace(ex.StackTrace);
            return ErrorResponse(ex.Message);
        }
    }
}