using LabApi.Domain.Entities.ClinicalTestAggregate;

namespace LabApi.Application.Dtos.ClinicalTest
{
    public sealed record ClinicalTestDetailsResponseDto
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
        public required decimal Price { get; init; }
        public required NormalValue[] NormalValues { get; init; }
    }
}
