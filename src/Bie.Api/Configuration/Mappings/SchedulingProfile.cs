using AutoMapper;

using Bie.Api.DTOs;
using Bie.Business.Models;

namespace Bie.Api.Configuration.Mappings;
public class SchedulingProfile : Profile
{
    public SchedulingProfile()
    {
        CreateMap<Scheduling, SchedulingRequestDto>();
        CreateMap<SchedulingRequestDto, Scheduling>()
        .ForMember(dest => dest.ScheduledDate, opt => opt.MapFrom(src => src.ScheduledDate.Date.Add(TimeSpan.Parse(src.TimeSelected))))
        .ForMember(dest => dest.ServicesOfferedId, opt => opt.MapFrom(src => src.ServiceSelectedId));
    }
}