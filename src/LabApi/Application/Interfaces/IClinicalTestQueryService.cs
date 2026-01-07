using LabApi.Application.Dtos.ClinicalTest;

namespace LabApi.Application.Interfaces;

public interface IClinicalTestQueryService
{
    Task<IReadOnlyList<ClinicalTestResponseDto>> GetAllAsync();
    Task<ClinicalTestDetailsResponseDto?> GetByIdAsync(int id);
}