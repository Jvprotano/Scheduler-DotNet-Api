using Agende.Business.Models;
using Microsoft.AspNetCore.Identity;

namespace Agende.Business.Interfaces.Services;
public interface IUserService
{
    Task<IdentityResult> UpdateAsync(ApplicationUser applicationUser);
}