using System.Data.Common;
using System.Net;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

using Bie.Api.Controllers.V1.Base;
using Bie.Api.DTOs.Request;
using Bie.Api.DTOs.Response;
using Bie.Business.Interfaces.Services;
using Bie.Business.Models;

namespace Bie.Api.Controllers.V1;

[Authorize]
[Route("api/v{version:apiVersion}/[controller]")]
public class CompanyController : BaseController
{
    private readonly ICompanyService _companyService;
    private readonly IMapper _mapper;

    public CompanyController(ICompanyService companyService, IMapper mapper) : base()
    {
        _companyService = companyService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CompanyRequestDto model)
    {
        try
        {
            var company = _mapper.Map<Company>(model);

            await _companyService.SaveAsync(company);

            return SuccessResponse(new { }, "Created successfuly.");
        }
        catch (Exception ex)
        {
            return ErrorResponse(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put([FromBody] CompanyRequestDto model)
    {
        try
        {
            if (model == null)
                throw new ArgumentNullException("Company not found");
            if (model.Id == default)
                throw new ArgumentNullException("Existing company must be informed");

            var company = _mapper.Map<Company>(model);

            await _companyService.SaveAsync(company);

            return SuccessResponse(new { }, "Updated successfuly.");
        }
        catch (ArgumentNullException ex)
        {
            return ErrorResponse(ex.Message, HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
            return ErrorResponse(ex.Message);
        }
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _companyService.TemporaryDeleteAsync(id);

            return SuccessResponse(new { }, "Deleted successfuly!");
        }
        catch (Exception ex)
        {
            return ErrorResponse(ex.Message);
        }
    }
    [Route("Reactive")]
    [HttpGet]
    public async Task<IActionResult> Reactive(Guid id)
    {
        try
        {
            await _companyService.ReactiveAsync(id);
            return SuccessResponse(new object());
        }
        catch (Exception ex)
        {
            return ErrorResponse(ex.Message);
        }
    }
    [HttpGet]
    [ProducesResponseType(typeof(CompanyResponseDto), 200)]
    public async Task<IActionResult> Get(Guid id)
    {
        var model = _mapper.Map<CompanyResponseDto>(await _companyService.GetByIdAsync(id));

        return SuccessResponse(model);
    }
    [HttpGet]
    [Route("GetBySchedulingUrl")]
    [ProducesResponseType(typeof(CompanyResponseDto), 200)]
    public async Task<IActionResult> GetBySchedulingUrl(string schedulingUrl)
    {
        var company = await _companyService.GetAll()
                                .Include(c => c.ServicesOffered)
                                .Include(c => c.Employeers)!.ThenInclude(c => c.User)
                                .FirstOrDefaultAsync(c => c.SchedulingUrl == schedulingUrl);

        var model = _mapper.Map<CompanyResponseDto>(company);

        return SuccessResponse(model);
    }
    [HttpGet]
    [Route("CheckUrlIsValid")]
    public async Task<IActionResult> CheckUrlIsValid([FromQuery] string schedulingUrl, [FromQuery] string? id = null)
    {
        try
        {
            bool urlIsValid = false;

            if (!string.IsNullOrWhiteSpace(id))
                urlIsValid = !await _companyService.GetAll().AnyAsync(c => c.SchedulingUrl == schedulingUrl && c.Id != Guid.Parse(id));

            urlIsValid = !await _companyService.GetAll().AnyAsync(c => c.SchedulingUrl == schedulingUrl);

            return SuccessResponse(urlIsValid);
        }
        catch (Exception ex)
        {
            return ErrorResponse(ex.Message);
        }
    }
    [HttpGet]
    [Route("GetByUserId")]
    [ProducesResponseType(typeof(List<CompanyResponseDto>), 200)]
    public async Task<IActionResult> GetByUserId(Guid userId)
    {
        try
        {
            if (userId == default)
                throw new ArgumentNullException("User not found");

            var companies = (await _companyService.GetCompaniesByUserAsync(userId)).ToList();

            if (companies == null || !companies.Any())
                return SuccessResponse(new object());

            var model = _mapper.Map<List<CompanyResponseDto>>(companies);
            return SuccessResponse(model);
        }
        catch (DbException ex)
        {
            return ErrorResponse(ex.Message);
        }
    }
}