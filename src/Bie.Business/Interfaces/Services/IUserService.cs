using Bie.Business.Models;
using Microsoft.AspNetCore.Identity;

namespace Bie.Business.Interfaces.Services;
public interface IUserService
{
    Task<IdentityResult> UpdateAsync(ApplicationUser applicationUser);
}