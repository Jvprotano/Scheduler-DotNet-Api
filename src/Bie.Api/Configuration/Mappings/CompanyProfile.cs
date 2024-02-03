using Bie.Business.Models;
using Bie.Api.DTOs;

using AutoMapper;

namespace Bie.Api.Configuration.Mappings;
public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<Company, CompanyViewModel>();
        CreateMap<CompanyViewModel, Company>();

        CreateMap<Company, SchedulingViewModel>()
        .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.ScheduledDate, opt => opt.MapFrom(src => DateTime.Now));
    }
}