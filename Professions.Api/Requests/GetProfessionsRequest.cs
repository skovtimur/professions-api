using System.ComponentModel.DataAnnotations;

namespace Professions.Api.Requests;

public class GetProfessionsRequest
{
    [Range(0, int.MaxValue)] public int? Start { get; set; } = null;
    [Range(1, int.MaxValue)] public int? TakeCount { get; set; } = null;

    [StringLength(49, MinimumLength = 1)] public string? ProfessionBeginning { get; set; } = null;
}