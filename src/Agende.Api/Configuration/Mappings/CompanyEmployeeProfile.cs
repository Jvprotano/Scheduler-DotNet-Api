using AutoMapper;
using Agende.Api.DTOs.Response;
using Agende.Business.Models;

namespace Agende.Api.Configuration.Mappings;
public class CompanyEmployeeProfile : Profile
{
    public CompanyEmployeeProfile()
    {
        CreateMap<CompanyEmployee, CompanyEmployeeDto>()
        .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? 
                                                                  src.User.FirstName : ""))
        .ForMember(dest => dest.UserImageUrl, opt => opt.MapFrom(src => src.User != null ? 
                                                                  src.User.ImageUrl : ""));
    }
}