using Microsoft.EntityFrameworkCore;
using Professions.Application.Abstraction;
using Professions.Domain.Dtos;
using Professions.Domain.Entities;

namespace Professions.Infrastructure.Repositories;

public class SkillRepository(MainDbContext context) : ISkillRepository
{
    public async Task<(List<SkillDtoToView> skills, int total)> GetSkills(int? start = null, int? takeCount = null,
        string? skillsBeginning = null)
    {
        var query = context.Skills.AsQueryable();

        if (string.IsNullOrWhiteSpace(skillsBeginning) == false)
        {
            query = context.Skills
                .Where(x => EF.Functions.Like(x.SkillName, skillsBeginning + "%"));
        }

        var total = await query.CountAsync();
        if (start != null && takeCount != null)
        {
            var remainder = total - start;

            if (remainder <= 0)
                throw new IndexOutOfRangeException("The number of skills is less than or equal to zero.");

            if (remainder < takeCount)
                takeCount = remainder;

            query = query.Skip((int)start);
            query = query.Take((int)takeCount);
        }

        var skills = await query
            .Include(x => x.Professions)
            .Select(x => new SkillDtoToView
            {
                Id = x.Id,
                SkillName = x.SkillName,
                Professions = x.Professions
            })
            .ToListAsync();

        return (skills, total);
    }
}