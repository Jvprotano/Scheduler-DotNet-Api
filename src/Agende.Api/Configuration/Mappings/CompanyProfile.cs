using Agende.Api.DTOs.Request;
using Agende.Api.DTOs.Response;
using Agende.Business.Models;
using AutoMapper;

namespace Agende.Api.Configuration.Mappings;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<CompanyRequestDto, Company>()
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj))
        .ForMember(dest => dest.SchedulingUrl, opt => opt.MapFrom(src => src.SchedulingUrl))
        .ForMember(dest => dest.ScheduleStatus, opt => opt.MapFrom(src => src.ScheduleStatus))
        .ForMember(dest => dest.ImageBase64, opt => opt.MapFrom(src => src.ImageBase64))
        .ForMember(dest => dest.OpeningHours, opt => opt.MapFrom((src, dest) =>
        {
            var openingHours = new List<CompanyOpeningHours>();
            if (src.Schedule != null)
            {
                foreach (var days in src.Schedule)
                {
                    foreach (var interval in days.Intervals)
                    {
                        openingHours.Add(new CompanyOpeningHours
                        {
                            DayOfWeek = days.DayOfWeek,
                            OpeningHour = TimeOnly.FromTimeSpan(interval.Start),
                            ClosingHour = TimeOnly.FromTimeSpan(interval.End)
                        });
                    }

                }
            }
            return openingHours;
        }));

        CreateMap<Company, CompanyResponseDto>();

        CreateMap<Company, SchedulingRequestDto>()
        .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.Now));
    }
}