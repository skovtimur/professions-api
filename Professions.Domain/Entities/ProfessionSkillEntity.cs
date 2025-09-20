namespace Professions.Domain.Entities;

public class ProfessionSkillEntity
{
    public Guid ProfessionId { get; set; }
    public ProfessionEntity Profession { get; set; } = null!;

    public Guid SkillId { get; set; }
    public SkillEntity Skill { get; set; } = null!;
    
    public SkillLevel Level { get; set; } = SkillLevel.None;
}

public enum SkillLevel
{
    None = 0,
    Junior = 1,
    Middle = 2,
    Senior = 3
}