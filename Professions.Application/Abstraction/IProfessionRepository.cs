using Professions.Domain.Dtos;
using Professions.Domain.Entities;

namespace Professions.Application.Abstraction;

public interface IProfessionRepository
{
    public Task<(List<ProfessionDtoToView> professions, int total)> GetProfessions(int? start = null,
        int? takeCount = null,
        string? professionsBeginning = null);
}