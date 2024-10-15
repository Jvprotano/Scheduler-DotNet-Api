using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Bie.Business.Interfaces.HttpServices;
using Bie.Business.Interfaces.Services;
using Bie.Business.Models;

namespace Bie.Business.Services;
public class UserService : UserManager<ApplicationUser>, IUserService
{
    private readonly IImageUploadService _imageUploadService;

    public UserService(IUserStore<ApplicationUser> store,
                       IOptions<IdentityOptions> optionsAccessor,
                       IPasswordHasher<ApplicationUser> passwordHasher,
                       IEnumerable<IUserValidator<ApplicationUser>> userValidators,
                       IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
                       ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors,
                       IServiceProvider services, ILogger<UserManager<ApplicationUser>> logger,
                       IImageUploadService imageService) :
                        base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
        _imageUploadService = imageService;
    }

    public override async Task<IdentityResult> UpdateAsync(ApplicationUser user)
    {
        var tempUser = await FindByIdAsync(user.Id.ToString());

        if (tempUser == null)
            return IdentityResult.Failed(new IdentityError { Description = "User not found." });

        if (user.ImageBase64 != null && user.ImageBase64.IsValid)
        {
            string url = await _imageUploadService.UploadImage(user.ImageBase64);



        }

        tempUser.ChangeUserInfo(user.FirstName, user.LastName, user.BirthDate, user.PhoneNumber = "");

        return await base.UpdateAsync(tempUser);
    }
}