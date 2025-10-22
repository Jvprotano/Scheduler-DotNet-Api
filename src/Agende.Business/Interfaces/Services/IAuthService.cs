using Agende.Business.Models;

namespace Agende.Business.Interfaces.Services;
public interface IAuthService
{
    Task<ApplicationUser?> CreateAsync(ApplicationUser user, string v);
    Task<ApplicationUser?> FindByEmailAsync(string email);
    Task<ApplicationUser?> FindByPhoneAsync(string phone);
    string GenerateToken(ApplicationUser user);
    Task<ApplicationUser?> LoginAsync(string emailOrPhone, string password, bool rememberMe);
}