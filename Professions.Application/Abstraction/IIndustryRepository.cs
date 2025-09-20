using Professions.Domain.Dtos;

namespace Professions.Application.Abstraction;

public interface IIndustryRepository
{
    public Task<(List<IndustryDtoToView> industries, int total)> GetIndustries(int? start = null, int? takeCount = null,
        string? industryBeginning = null);
}