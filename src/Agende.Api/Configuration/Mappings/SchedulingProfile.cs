using AutoMapper;
using Agende.Api.DTOs.Request;
using Agende.Business.Models;

namespace Agende.Api.Configuration.Mappings;
public class SchedulingProfile : Profile
{
    public SchedulingProfile()
    {
        CreateMap<SchedulingRequestDto, Scheduling>()
        .ForMember(dest => dest.ServicesOfferedId, opt => opt.MapFrom(src => src.ServiceId))
        .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.ProfessionalId))
        .ForMember(dest => dest.Time, opt => opt.MapFrom(src => TimeOnly.Parse(src.Time)));
    }
}