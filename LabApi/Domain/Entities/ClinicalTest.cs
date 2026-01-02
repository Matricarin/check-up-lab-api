using LabApi.Core.Models;

namespace LabApi.Domain.Entities;

public sealed class ClinicalTest
{
    private readonly List<NormalValue> _normalValues = new();
    public string Description { get; private set; }

    public int Id { get; private set; }

    public string Name { get; private set; }

    public IReadOnlyCollection<NormalValue> NormalValues => _normalValues;

    public decimal Price { get; private set; }

    private ClinicalTest() { }

    public ClinicalTest(string name, string description, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException("name");
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentNullException("description");
        }

        if (price <= 0)
        {
            throw new ArgumentNullException("price");
        }

        Name = name;
        Description = description;
        Price = price;
    }

    public void AddNormalValue(NormalValue value)
    {
        if (_normalValues.Any(v =>
                v.Sex == value.Sex &&
                v.AgeRange.Equals(value.AgeRange)))
        {
            throw new InvalidOperationException(
                "Normal value for this age range and sex already exists.");
        }

        _normalValues.Add(value);
    }

    public void RemoveNormalValue(NormalValue value)
    {
        if (_normalValues.Any(v =>
                v.Sex == value.Sex &&
                v.AgeRange.Equals(value.AgeRange)))
        {
            _normalValues.Remove(value);
        }
    }
}