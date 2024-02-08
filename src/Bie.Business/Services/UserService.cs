using Bie.Business.Interfaces.Services;
using Bie.Business.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bie.Business.Services;
public class UserService : UserManager<ApplicationUser>, IUserService
{
    public UserService(IUserStore<ApplicationUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<ApplicationUser> passwordHasher, IEnumerable<IUserValidator<ApplicationUser>> userValidators, IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<ApplicationUser>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
    }

    public override async Task<IdentityResult> UpdateAsync(ApplicationUser user)
    {
        var tempUser = await FindByIdAsync(user.Id);

        if (tempUser == null)
            return IdentityResult.Failed(new IdentityError { Description = "User not found." });

        tempUser.FirstName = user.FirstName;
        tempUser.LastName = user.LastName;
        tempUser.BirthDate = user.BirthDate;

        return await base.UpdateAsync(tempUser);
    }
}