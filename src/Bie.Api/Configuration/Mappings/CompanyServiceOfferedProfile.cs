using AutoMapper;
using Bie.Api.DTOs.Response;
using Bie.Business.Models;

namespace Bie.Api.Configuration.Mappings;
public class CompanyServiceOfferedProfile : Profile
{
    public CompanyServiceOfferedProfile()
    {
        CreateMap<CompanyServiceOffered, CompanyServiceOfferedDto>(); 
    }
}