using Microsoft.EntityFrameworkCore;
using Professions.Application.Abstraction;
using Professions.Domain.Dtos;
using Professions.Domain.Entities;

namespace Professions.Infrastructure.Repositories;

public class IndustryRepository(MainDbContext context) : IIndustryRepository
{
    public async Task<(List<IndustryDtoToView> industries, int total)> GetIndustries(int? start = null,
        int? takeCount = null,
        string? industryBeginning = null)
    {
        var query = context.Industries.AsQueryable();

        if (string.IsNullOrWhiteSpace(industryBeginning) == false)
        {
            query = context.Industries
                .Where(x => EF.Functions.Like(x.IndustryName, industryBeginning + "%"));
        }

        var total = await query.CountAsync();

        if (start != null && takeCount != null)
        {
            var remainder = total - start;

            if (remainder <= 0)
                throw new IndexOutOfRangeException("The number of industries is less than or equal to zero.");

            if (remainder < takeCount)
                takeCount = remainder;

            query = query.Skip((int)start);
            query = query.Take((int)takeCount);
        }

        var industryEntities = await query
            .Include(x => x.Professions)
            .ThenInclude(x => x.Skills)
            .ThenInclude(x => x.Skill)
            .Select(x => new IndustryDtoToView
            {
                Id = x.Id,
                IndustryName = x.IndustryName,
            })
            .ToListAsync();

        return (industryEntities, total);
    }
}