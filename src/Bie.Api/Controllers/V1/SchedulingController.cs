using Asp.Versioning;

using AutoMapper;

using Bie.Api.Controllers.V1.Base;
using Bie.Api.DTOs;
using Bie.Business.Interfaces.Services;
using Bie.Business.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bie.Api.Controllers.V1;

[Route("[controller]")]
[ApiVersion("1.0")]
public class SchedulingController : BaseController
{
    private readonly ISchedulingService _serviceScheduling;
    private readonly IMapper _mapper;

    public SchedulingController(IMapper mapper, ISchedulingService serviceScheduling) : base()
    {
        _mapper = mapper;
        _serviceScheduling = serviceScheduling;
    }
    // [HttpGet("{companyId}")]
    // public async Task<IActionResult> Create(string companyId)
    // {
    //     var company = await _companyService.GetByIdAsync(companyId);

    //     if (company == null)
    //     {
    //         ModelState.AddModelError("Company", "Company not found");
    //         return ("Index", "Home");
    //     }
    //     if (!company.ServicesOffered.Any())
    //     {
    //         ModelState.AddModelError("ServicesOffered", "Company has no services offered");
    //         return ("Index", "Home");
    //     }
    //     if (company.ScheduleStatus != ScheduleStatusEnum.Open)
    //     {
    //         ModelState.AddModelError("ScheduleStatus", "Company schedule is closed");
    //         return ("Index", "Home");
    //     }

    //     var model = _mapper.Map<SchedulingViewModel>(company);

    //     model.CompanyServices = company.ServicesOffered
    //         .Select(item => new SelectListItem
    //         {
    //             Value = item.Id.ToString(),
    //             Text = $"{item.Name} - {item.Price:C}"
    //         }).ToList();

    //     List<TimeSpan> availableTimes = (await _serviceScheduling.GetAvailableTimesAsync(company.Id, company.ServicesOffered.FirstOrDefault().Id, DateOnly.FromDateTime(DateTime.Now))).ToList();

    //     model.AvailableTimeSlots = availableTimes
    //         .Select(item => new SelectListItem
    //         {
    //             Value = item.ToString(),
    //             Text = TimeOnly.Parse(item.ToString()).ToString()
    //         }).ToList();

    //     //return View(model);
    //     return Ok(model);
    // }
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] SchedulingViewModel model)
    {
        try
        {
            if (String.IsNullOrWhiteSpace(model.TimeSelected))
                throw new Exception("Time is required");
            if (String.IsNullOrWhiteSpace(model.ServiceSelectedId))
                throw new Exception("Service is required");
            if (model.ScheduledDate == default)
                throw new Exception("Date is required");

            var scheduling = _mapper.Map<Scheduling>(model);

            // if (User.Identities.Any(c => c.IsAuthenticated))
            // {
            //     var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            //     scheduling.CustomerId = user.Id;
            // }

            await _serviceScheduling.SaveAsync(scheduling);
        }
        catch (Exception ex)
        {
            return Ok(ex.Message);
        }
        return Ok(model);
    }

    [HttpPost]
    [Route("GetAvailableTimeSlots")]
    public async Task<JsonResult> GetAvailableTimeSlots(string companyId, string serviceSelected, DateOnly dateSelected)
    {
        try
        {
            List<TimeSpan> listTimes = (await _serviceScheduling.GetAvailableTimesAsync(companyId, serviceSelected, dateSelected)).ToList();

            Response.StatusCode = 200;
            // return Json(listTimes);
            return new JsonResult(listTimes);

        }
        catch (Exception ex)
        {
            Response.StatusCode = 500;
            // return Json(ex.Message);
            return new JsonResult(ex.Message);
        }

    }
}