using AutoMapper;
using Bie.Api.DTOs.Response;
using Bie.Business.Models;

namespace Bie.Api.Configuration.Mappings;
public class CompanyEmployeeProfile : Profile
{
    public CompanyEmployeeProfile()
    {
        CreateMap<CompanyEmployee, CompanyEmployeeDto>()
        .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? 
                                                                  src.User.FirstName : ""));
    }
}