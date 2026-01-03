namespace LabApi.Domain.Entities.ClinicalTestAggregate;

public sealed class NormalValue : ValueObject
{
    public int AgeFrom { get; private set; }
    public int AgeTo { get; private set; }
    public Sex Sex { get; private set; }
    public string MeasurementUnit { get; private set; }
    public decimal Value { get; private set; }

    private NormalValue() { }

    public NormalValue(Sex sex, int ageFrom, int ageTo, string measurementUnit, decimal value)
    {
        if (ageTo <= 0)
        {
            throw new ArgumentException();
        }

        if (ageTo <= ageFrom)
        {
            throw new ArgumentException();
        }

        if (string.IsNullOrWhiteSpace(measurementUnit))
        {
            throw new ArgumentNullException();
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