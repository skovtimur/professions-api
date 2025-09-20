using Microsoft.EntityFrameworkCore;
using Professions.Application.Abstraction;
using Professions.Domain.Dtos;

namespace Professions.Infrastructure.Repositories;

public class ProfessionRepository(MainDbContext context) : IProfessionRepository
{
    public async Task<(List<ProfessionDtoToView> professions, int total)> GetProfessions(int? start = null,
        int? takeCount = null,
        string? professionsBeginning = null)
    {
        var query = context.Professions.AsQueryable();

        if (string.IsNullOrWhiteSpace(professionsBeginning) == false)
        {
            query = context.Professions
                .Where(x => EF.Functions.Like(x.ProfessionName, professionsBeginning + "%"));
        }

        var total = await query.CountAsync();
        if (start != null && takeCount != null)
        {
            var remainder = total - start;

            if (remainder <= 0)
                throw new IndexOutOfRangeException("The number of professions is less than or equal to zero.");

            if (remainder < takeCount)
                takeCount = remainder;

            query = query.Skip((int)start);
            query = query.Take((int)takeCount);
        }

        var professions = await query
            .Include(x => x.Industry)
            .Include(x => x.Skills)
            .ThenInclude(x => x.Skill)
            .Select(x => new ProfessionDtoToView
            {
                Id = x.Id,
                Industry = new IndustryDtoToView { Id = x.IndustryId, IndustryName = x.Industry.IndustryName },
                IndustryId = x.IndustryId,
                ProfessionName = x.ProfessionName,
                Skills = x.Skills.Select(y => new SkillPartialDtoToView
                    { Id = y.SkillId, SkillName = y.Skill.SkillName, Level = y.Level }).ToList()
            })
            .ToListAsync();

        return (professions, total);
    }
}