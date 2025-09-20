namespace Professions.Domain.Entities;

public class ProfessionEntity : BaseEntity
{
    public required string ProfessionName { get; init; }
    public List<ProfessionSkillEntity> Skills { get; init; } = [];

    public required Guid IndustryId { get; init; }
    public IndustryEntity Industry { get; init; }
}