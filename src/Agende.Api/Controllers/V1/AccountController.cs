using System.Data.Common;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Agende.Api.Controllers.V1.Base;
using Agende.Api.DTOs.Request;
using Agende.Api.DTOs.Response;
using Agende.Api.Validators;
using Agende.Business.Interfaces.Services;
using Agende.Business.Models;
using AutoMapper;

namespace Agende.Api.Controllers.V1;

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
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
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
                return ErrorResponse("User not found or password is incorrect", HttpStatusCode.Unauthorized);
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
    public async Task<IActionResult> Register([FromBody] RegisterDto request)
    {
        try
        {
            FluentValidation.Results.ValidationResult validationResult = await new RegisterDtoValidator().ValidateAsync(request);

            if (!validationResult.IsValid)
                return ErrorResponse(validationResult.ToString());

            var appUser = _mappper.Map<ApplicationUser>(request);
            var user = await _authService.CreateAsync(appUser, request.Password);

            if (user != null)
            {
                var userResponse = new UserResponseDto()
                {
                    Id = user.Id,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email
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