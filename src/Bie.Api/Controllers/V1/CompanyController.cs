using Asp.Versioning;

using AutoMapper;

using Bie.Api.Controllers.V1.Base;
using Bie.Api.DTOs;
using Bie.Business.Interfaces.Services;
using Bie.Business.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bie.Api.Controllers.V1;

[Authorize]
[ApiVersion(1.0)]
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
    public async Task<IActionResult> Post([FromBody] CompanyViewModel model)
    {
        try
        {
            var company = _mapper.Map<Company>(model);

            await _companyService.SaveAsync(company);

            return Ok(company);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put([FromBody] CompanyViewModel model)
    {
        try
        {
            var company = _mapper.Map<Company>(model);

            await _companyService.SaveAsync(company);

            return Ok(company);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await _companyService.TemporaryDeleteAsync(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    [Route("Reactive")]
    [HttpGet]
    public async Task<IActionResult> Reactive(string id)
    {
        try
        {
            await _companyService.ReactiveAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    [HttpGet]
    public async Task<IActionResult> Get(string id)
    {
        var company = await _companyService.GetByIdAsync(id);
        return Ok(company);
    }
    [HttpGet]
    [Route("GetByUserId")]
    public async Task<IActionResult> GetByUserId(string userId)
    {
        var userName = User != null && User.Identity != null ? User.Identity.Name : null;
        if (userName != null)
        {
            // var user = await _userManager.FindByNameAsync(userName);
            // if (user != null)
            // {
            //     user.Companies = (await _serviceCompany.GetCompaniesByUserAsync(user.Id)).ToList();
            //     var model = _mappper.Map<AccountViewModel>(user);
            //     return Ok(model);
            // }
        }

        return NotFound();
    }
}