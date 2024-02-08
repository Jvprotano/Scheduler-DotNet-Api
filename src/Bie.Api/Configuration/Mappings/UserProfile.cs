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

        CreateMap<RegisterDto, ApplicationUser>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Business.Enums.StatusEnum.Active));

        CreateMap<LoginDto, ApplicationUser>();
        CreateMap<ApplicationUser, UserResponseDto>();

        CreateMap<UserRequestDto, ApplicationUser>();
    }
}