using AutoMapper;

using Bie.Api.DTOs.Request;
using Bie.Api.DTOs.Response;
using Bie.Business.Models;

namespace Bie.Api.Configuration.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserResponseDto, ApplicationUser>();
        CreateMap<RegisterDto, ApplicationUser>();
        CreateMap<LoginDto, ApplicationUser>();
    }
}