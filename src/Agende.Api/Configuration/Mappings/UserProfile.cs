using AutoMapper;

using Agende.Api.DTOs.Request;
using Agende.Api.DTOs.Response;
using Agende.Business.Models;

namespace Agende.Api.Configuration.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterDto, ApplicationUser>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Business.Enums.StatusEnum.Active))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

        CreateMap<LoginDto, ApplicationUser>();
        CreateMap<ApplicationUser, UserResponseDto>();

        CreateMap<UserRequestDto, ApplicationUser>();
    }
}