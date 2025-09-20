using Professions.Domain;

namespace Professions.Infrastructure.Entities;

public class ProfessionSkillEntity
{
    public Guid ProfessionId { get; set; }
    public ProfessionEntity Profession { get; set; } = null!;

    public Guid SkillId { get; set; }
    public SkillEntity Skill { get; set; } = null!;
    
    public SkillLevel Level { get; set; } = SkillLevel.None;
}