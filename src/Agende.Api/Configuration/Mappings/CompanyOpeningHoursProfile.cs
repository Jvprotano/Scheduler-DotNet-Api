using AutoMapper;
using Agende.Api.DTOs.Response;
using Agende.Business.Models;

namespace Agende.Api.Configuration.Mappings;
public class CompanyOpeningHoursProfile : Profile
{
    public CompanyOpeningHoursProfile()
    {
        CreateMap<CompanyOpeningHours, CompanyOpeningHoursDto>();
    }
}