using Bie.Api.Controllers.V1.Base;
using Bie.Api.DTOs.Response;
using Bie.Business.Enums;
using Bie.Business.Interfaces.Services;

using Microsoft.AspNetCore.Mvc;

namespace Bie.Api.Controller;

[Route("api/v{version:apiVersion}/[controller]")]
public class ScheduleController : BaseController
{
    private readonly ICompanyService _companyService;

    public ScheduleController(ICompanyService companyService)
    {
        _companyService = companyService;
    }
    [HttpGet]
    [Route("Close")]
    [ProducesResponseType(typeof(ApiResponse), 200)]
    [ProducesResponseType(typeof(ApiResponse), 400)]

    public async Task<IActionResult> Close(string companyId)
    {
        try
        {
            var company = await _companyService.GetByIdAsync(companyId);

            company.ScheduleStatus = ScheduleStatusEnum.Closed;

            await _companyService.SaveAsync(company);

            return SuccessResponse("Schedule closed successfully");
        }
        catch (Exception ex)
        {
            return ErrorResponse(ex.Message);
        }
    }
    [HttpGet]
    [Route("Open/{companyId}")]
    public async Task<IActionResult> Open([FromRoute] string companyId)
    {
        try
        {
            var company = await _companyService.GetByIdAsync(companyId);

            company.ScheduleStatus = ScheduleStatusEnum.Open;

            await _companyService.SaveAsync(company);

            return SuccessResponse("Schedule opened successfully");
        }
        catch (Exception ex)
        {
            return ErrorResponse(ex.Message);
        }

    }
}