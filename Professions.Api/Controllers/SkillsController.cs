using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Professions.Api.Requests;
using Professions.Application.Abstraction;

namespace Professions.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillsController(ISkillRepository repository) : ControllerBase
{
    public const string TotalCountHeaderName = "x-skills-total-count";

    [HttpGet]
    public async Task<IActionResult> GetProfessions([Required, FromQuery] GetSkillsRequest request)
    {
        if (request is { Start: not null, TakeCount: not null }
            && request.Start > request.TakeCount)
            return BadRequest("Start must be less than TakeCount");

        try
        {
            var (skills, total) =
                await repository.GetSkills(request.Start, request.TakeCount,
                    request.SkillBeginning);

            Response.Headers.Append(TotalCountHeaderName, total.ToString());
            return Ok(skills);
        }
        catch (IndexOutOfRangeException exception)
        {
            return BadRequest(exception.Message);
        }
    }
}