using Bie.Business.Models;

namespace Bie.Business.Interfaces.Services;
public interface IAuthService
{
    string GenerateToken(ApplicationUser user);
}