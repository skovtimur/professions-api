using Professions.Domain.Entities;

namespace Professions.Domain.Dtos;

public class ProfessionDtoToView
{
    public required Guid Id { get; init; } 
    public required string ProfessionName { get; init; }
    public required List<ProfessionSkillEntity> Skills { get; init; } = [];

    public required Guid IndustryId { get; init; }
    public required IndustryEntity Industry { get; init; }
}