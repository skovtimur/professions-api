using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Professions.Api.Requests;
using Professions.Application.Abstraction;

namespace Professions.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfessionsController(IProfessionRepository professionRepository) : ControllerBase
{
    public const string TotalCountHeaderName = "x-professions-total-count";

    [HttpGet]
    public async Task<IActionResult> GetProfessions([Required, FromQuery] GetProfessionsRequest request)
    {
        if (request is { Start: not null, TakeCount: not null }
            && request.Start > request.TakeCount)
            return BadRequest("Start must be less than TakeCount");
        
        try
        {
            var (professions, total) =
                await professionRepository.GetProfessions(request.Start, request.TakeCount,
                    request.ProfessionBeginning);

            Response.Headers.Append(TotalCountHeaderName, total.ToString());
            return Ok(professions);
        }
        catch (IndexOutOfRangeException exception)
        {
            return BadRequest(exception.Message);
        }
    }
}