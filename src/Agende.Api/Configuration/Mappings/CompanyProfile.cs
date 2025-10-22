using AutoMapper;
using Agende.Api.DTOs.Request;
using Agende.Api.DTOs.Response;
using Agende.Business.Models;

namespace Agende.Api.Configuration.Mappings;
public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<CompanyRequestDto, Company>();
        CreateMap<Company, CompanyResponseDto>();

        CreateMap<Company, SchedulingRequestDto>()
        .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.Now));
    }
}