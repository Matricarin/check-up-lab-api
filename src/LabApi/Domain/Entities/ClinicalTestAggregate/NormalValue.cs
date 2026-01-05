namespace LabApi.Domain.Entities.ClinicalTestAggregate;

public sealed class NormalValue : ValueObject
{
    public int AgeFrom { get; }
    public int AgeTo { get; }
    public string MeasurementUnit { get; }
    public Sex Sex { get; }
    public decimal Value { get; }

    private NormalValue() { }

    public NormalValue(Sex sex, int ageFrom, int ageTo, string measurementUnit, decimal value)
    {
        if (ageTo <= 0)
        {
            throw new ArgumentException(nameof(ageTo));
        }

        if (ageFrom < 0)
        {
            throw new ArgumentException(nameof(ageFrom));
        }

        if (ageTo <= ageFrom)
        {
            throw new ArgumentException(nameof(ageTo) + " is less then " + nameof(ageFrom));
        }

        if (string.IsNullOrWhiteSpace(measurementUnit))
        {
            throw new ArgumentNullException(nameof(measurementUnit));
        }

        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }

        AgeFrom = ageFrom;
        AgeTo = ageTo;
        Sex = sex;
        MeasurementUnit = measurementUnit;
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Sex;
        yield return AgeFrom;
        yield return AgeTo;
        yield return MeasurementUnit;
        yield return Value;
    }
}