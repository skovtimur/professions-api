namespace Professions.Domain.Entities;

public class SkillEntity : BaseEntity
{
    public required string SkillName { get; init; }

    public List<ProfessionSkillEntity> Professions { get; init; } = [];
}