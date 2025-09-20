namespace Professions.Domain.Dtos;

public class ProfessionDtoToView
{
    public required Guid Id { get; init; } 
    public required string ProfessionName { get; init; }
    public required List<SkillPartialDtoToView> Skills { get; init; } = [];

    public required Guid IndustryId { get; init; }
    public required IndustryDtoToView Industry { get; init; }
}