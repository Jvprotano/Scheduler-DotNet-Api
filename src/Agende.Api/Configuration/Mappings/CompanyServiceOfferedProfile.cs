using AutoMapper;
using Agende.Api.DTOs.Response;
using Agende.Business.Models;

namespace Agende.Api.Configuration.Mappings;
public class CompanyServiceOfferedProfile : Profile
{
    public CompanyServiceOfferedProfile()
    {
        CreateMap<CompanyServiceOffered, CompanyServiceOfferedDto>(); 
    }
}