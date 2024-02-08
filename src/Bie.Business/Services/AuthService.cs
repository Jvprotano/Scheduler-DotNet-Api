using Bie.Business.Interfaces.Services;
using Bie.Business.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bie.Business.Services;
public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthService(IConfiguration configuration, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _configuration = configuration;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public Task<string> Register(string email, string password, string confirmPassword)
    {
        throw new NotImplementedException();
    }
    public async Task<ApplicationUser?> FindByPhoneAsync(string phone)
    {
        return await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phone);
    }
    public string GenerateToken(ApplicationUser user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.UniqueName, user.Email ?? "")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? ""));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<ApplicationUser?> LoginAsync(string emailOrPhone, string password, bool rememberMe)
    {
        var user = await _userManager.FindByEmailAsync(emailOrPhone);

        user ??= await this.FindByPhoneAsync(emailOrPhone);

        if (user == null)
            return null;

        var result = await _signInManager.PasswordSignInAsync(user?.UserName ?? emailOrPhone ?? "", password ?? "", rememberMe, lockoutOnFailure: false);

        return result.Succeeded ? user : null;
    }

    public async Task<ApplicationUser?> FindByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<ApplicationUser?> CreateAsync(ApplicationUser user, string password)
    {
        var result = await _userManager.CreateAsync(user, password ?? "");

        if (result.Succeeded)
            return await _userManager.FindByEmailAsync(user.Email ?? "");

        return null;
    }
}