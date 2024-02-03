using Bie.Business.Models;
using Bie.Api.DTOs;
using AutoMapper;

namespace Bie.Api.Configuration.Mappings;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserViewModel, ApplicationUser>();
        CreateMap<RegisterViewModel, ApplicationUser>();
        CreateMap<LoginViewModel, ApplicationUser>();
    }
}