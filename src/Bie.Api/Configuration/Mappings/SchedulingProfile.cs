using AutoMapper;
using Bie.Api.DTOs.Request;
using Bie.Business.Models;

namespace Bie.Api.Configuration.Mappings;
public class SchedulingProfile : Profile
{
    public SchedulingProfile()
    {
        CreateMap<SchedulingRequestDto, Scheduling>()
        .ForMember(dest => dest.ServicesOfferedId, opt => opt.MapFrom(src => src.ServiceId))
        .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.ProfessionalId));
    }
}