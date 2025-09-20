using Professions.Domain.Entities;

namespace Professions.Domain.Dtos;

public class SkillDtoToView
{
    public required Guid Id { get; init; }
    public required string SkillName { get; init; }

    public List<ProfessionSkillEntity> Professions { get; init; } = [];
}