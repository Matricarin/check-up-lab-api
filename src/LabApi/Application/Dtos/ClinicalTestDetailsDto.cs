using LabApi.Domain.Entities.ClinicalTestAggregate;

namespace LabApi.Application.Dtos
{
    public sealed record ClinicalTestDetailsDto
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
        public required decimal Price { get; init; }
        public required NormalValue[] NormalValues { get; init; }
    }
}
