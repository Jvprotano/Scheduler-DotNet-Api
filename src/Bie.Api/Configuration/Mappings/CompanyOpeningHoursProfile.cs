using AutoMapper;
using Bie.Api.DTOs.Response;
using Bie.Business.Models;

namespace Bie.Api.Configuration.Mappings;
public class CompanyOpeningHoursProfile : Profile
{
    public CompanyOpeningHoursProfile()
    {
        CreateMap<CompanyOpeningHours, CompanyOpeningHoursDto>();
    }
}