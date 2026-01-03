using LabApi.Application.Dtos;
using LabApi.Application.Interfaces;

namespace LabApi.Application.Services;

public sealed class ClinicalTestQueryService : IClinicalTestQueryService
{
    public Task<IReadOnlyList<ClinicalTestDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ClinicalTestDetailsDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}