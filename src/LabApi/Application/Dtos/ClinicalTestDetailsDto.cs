using LabApi.Domain.Entities.ClinicalTestAggregate;

namespace LabApi.Application.Dtos
{
    public sealed class ClinicalTestDetailsDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required NormalValue[] NormalValues { get; set; }
    }
}
