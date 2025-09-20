using Professions.Domain.Dtos;

namespace Professions.Application.Abstraction;

public interface ISkillRepository
{
    public Task<(List<SkillDtoToView> skills, int total)> GetSkills(int? start = null, int? takeCount = null,
        string? skillsBeginning = null);
}