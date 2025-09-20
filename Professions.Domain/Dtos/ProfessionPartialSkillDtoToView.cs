namespace Professions.Domain.Dtos;

public class ProfessionPartialSkillDtoToView
{
    public Guid ProfessionId { get; set; }
    public string ProfessionName { get; set; }

    public Guid SkillId { get; set; }
    public SkillLevel Level { get; set; } = SkillLevel.None;
}