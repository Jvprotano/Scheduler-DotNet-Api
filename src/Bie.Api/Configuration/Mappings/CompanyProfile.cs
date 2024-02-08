using AutoMapper;
using Bie.Api.DTOs.Request;
using Bie.Api.DTOs.Response;
using Bie.Business.Models;

namespace Bie.Api.Configuration.Mappings;
public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<Company, CompanyRequestDto>().ReverseMap();
        CreateMap<Company, CompanyResponseDto>().ReverseMap();

        CreateMap<Company, SchedulingRequestDto>()
        .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.ScheduledDate, opt => opt.MapFrom(src => DateTime.Now));
    }
}