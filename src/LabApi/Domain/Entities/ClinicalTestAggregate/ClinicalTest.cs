namespace LabApi.Domain.Entities.ClinicalTestAggregate;

public sealed class ClinicalTest
{
    private readonly List<NormalValue> _normalValues = [];

    public string Description { get; }

    public int Id { get; private set; }

    public string Name { get; }

    public IReadOnlyCollection<NormalValue> NormalValues => _normalValues;

    public decimal Price { get; }

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
            throw new ArgumentException("price");
        }

        Name = name;
        Description = description;
        Price = price;
    }

    public override bool Equals(object? obj)
    {
        return ReferenceEquals(this, obj) || (obj is ClinicalTest other && Equals(other));
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Description, Name, Price);
    }

    public void AddNormalValue(NormalValue value)
    {
        if (_normalValues.Any(v =>
                v.Sex == value.Sex
                && v.AgeFrom.Equals(value.AgeFrom)
                && v.AgeTo.Equals(value.AgeTo)))
        {
            throw new InvalidOperationException(
                "Normal value for this age range and sex already exists.");
        }

        _normalValues.Add(value);
    }

    public void RemoveNormalValue(NormalValue value)
    {
        if (_normalValues.Any(v =>
                v.Sex == value.Sex
                && v.AgeFrom.Equals(value.AgeFrom)
                && v.AgeTo.Equals(value.AgeTo)))
        {
            _normalValues.Remove(value);
        }
        else
        {
            throw new InvalidOperationException("Tried to remove not existed value.");
        }
    }

    private bool Equals(ClinicalTest other)
    {
        return Description == other.Description && Name == other.Name && Price == other.Price;
    }
}