using AutoMapper;

using Agende.Api.Controllers.V1.Base;
using Agende.Api.DTOs.Request;
using Agende.Api.DTOs.Response;
using Agende.Business.Interfaces.Services;
using Agende.Business.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Data.Common;
using System.Net;

namespace Agende.Api.Controllers.V1;

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
            if (model.Id == null || model.Id == default)
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
    public async Task<IActionResult> Delete(string id)
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
    public async Task<IActionResult> Reactive(string id)
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
    public async Task<IActionResult> Get(string id)
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
                                .Include(c => c.Employeers).ThenInclude(c => c.User)
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
                urlIsValid = !await _companyService.GetAll().AnyAsync(c => c.SchedulingUrl == schedulingUrl && c.Id != id);

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
    public async Task<IActionResult> GetByUserId(string userId)
    {
        try
        {
            if (userId == null)
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