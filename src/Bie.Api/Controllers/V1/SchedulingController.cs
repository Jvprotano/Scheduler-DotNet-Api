using AutoMapper;

using Bie.Api.Controllers.V1.Base;
using Bie.Api.DTOs.Request;
using Bie.Api.DTOs.Response;
using Bie.Business.Interfaces.Services;
using Bie.Business.Models;

using Microsoft.AspNetCore.Mvc;

namespace Bie.Api.Controllers.V1;

[Route("api/v{version:apiVersion}/[controller]")]
public class SchedulingController : BaseController
{
    private readonly ISchedulingService _serviceScheduling;
    private readonly IMapper _mapper;

    public SchedulingController(IMapper mapper, ISchedulingService serviceScheduling) : base()
    {
        _mapper = mapper;
        _serviceScheduling = serviceScheduling;
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SchedulingRequestDto model)
    {
        try
        {
            if (model.TimeSelected == default)
                throw new Exception("Time is required");
            if (string.IsNullOrWhiteSpace(model.ServiceId))
                throw new Exception("Service is required");
            if (model.ScheduledDate == default)
                throw new Exception("Date is required");

            var scheduling = _mapper.Map<Scheduling>(model);

            await _serviceScheduling.SaveAsync(scheduling);
        }
        catch (Exception ex)
        {
            return ErrorResponse(ex.Message);
        }

        return SuccessResponse(model);
    }

    [HttpGet]
    [Route("GetAvailableTimeSlots")]
    [ProducesResponseType(typeof(ApiResponse), 200)]
    [ProducesResponseType(typeof(ApiResponse), 400)]
    public async Task<IActionResult> GetAvailableTimeSlots(string companyId, string serviceSelectedId, DateOnly dateSelected)
    {
        try
        {
            List<TimeOnly> listTimes = (await _serviceScheduling.GetAvailableTimesAsync(companyId, serviceSelectedId, dateSelected)).ToList();

            return SuccessResponse(listTimes);
        }
        catch (Exception ex)
        {
            return ErrorResponse(ex.Message);
        }
    }
}