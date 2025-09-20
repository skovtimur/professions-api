namespace Professions.Infrastructure.Entities;

public class IndustryEntity : BaseEntity
{
    public required string IndustryName { get; init; }
    public List<ProfessionEntity> Professions { get; init; } = [];
}