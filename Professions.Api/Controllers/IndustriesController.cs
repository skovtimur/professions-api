using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Professions.Api.Requests;
using Professions.Application.Abstraction;

namespace Professions.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IndustriesController(IIndustryRepository repository) : ControllerBase
{
    public const string TotalCountHeaderName = "x-industries-total-count";

    [HttpGet]
    public async Task<IActionResult> GetProfessions([Required, FromQuery] GetIndustriesRequest request)
    {
        if (request is { Start: not null, TakeCount: not null }
            && request.Start > request.TakeCount)
            return BadRequest("Start must be less than TakeCount");

        try
        {
            var (industries, total) =
                await repository.GetIndustries(request.Start, request.TakeCount,
                    request.IndustryBeginning);

            Response.Headers.Append(TotalCountHeaderName, total.ToString());
            return Ok(industries);
        }
        catch (IndexOutOfRangeException exception)
        {
            return BadRequest(exception.Message);
        }
    }
}