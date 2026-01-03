using LabApi.Application.Dtos;

namespace LabApi.Application.Interfaces
{
    public interface IClinicalTestQueryService
    {
        Task<IReadOnlyList<ClinicalTestDto>> GetAllAsync();
        Task<ClinicalTestDetailsDto?> GetByIdAsync(int id);
    }
}
