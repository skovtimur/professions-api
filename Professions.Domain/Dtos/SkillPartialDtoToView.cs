namespace Professions.Domain.Dtos;

public class SkillPartialDtoToView
{
    public required Guid Id { get; init; }
    public required string SkillName { get; init; }
    public required SkillLevel Level { get; init; }
}