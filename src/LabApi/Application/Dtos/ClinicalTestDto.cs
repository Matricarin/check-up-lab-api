namespace LabApi.Application.Dtos
{
    public sealed class ClinicalTestDto
    {
        public ClinicalTestDto(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
