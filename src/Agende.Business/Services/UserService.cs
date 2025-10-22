using Agende.Business.Interfaces.HttpServices;
using Agende.Business.Interfaces.Services;
using Agende.Business.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Agende.Business.Services;
public class UserService : UserManager<ApplicationUser>, IUserService
{
    private readonly IImageUploadService _imageService;

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
        _imageService = imageService;
    }

    public override async Task<IdentityResult> UpdateAsync(ApplicationUser user)
    {
        var tempUser = await FindByIdAsync(user.Id);

        if (tempUser == null)
            return IdentityResult.Failed(new IdentityError { Description = "User not found." });

        if (!string.IsNullOrWhiteSpace(user.ImageBase64))
            tempUser.ImageUrl = await _imageService.UploadImage(user.ImageBase64);

        tempUser.FirstName = user.FirstName;
        tempUser.LastName = user.LastName;
        tempUser.BirthDate = user.BirthDate;
        tempUser.PhoneNumber = user.PhoneNumber;

        return await base.UpdateAsync(tempUser);
    }
}