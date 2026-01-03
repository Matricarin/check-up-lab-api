namespace LabApi.Domain.Entities.ClinicalTestAggregate;

public sealed class NormalValue : ValueObject
{
    public Sex Sex { get; set; }
    public decimal Value { get; set; }

    private NormalValue() { }

    public NormalValue(AgeRange ageRange, Sex sex, MeasurementUnit unit, decimal value)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }

        AgeRange = ageRange;
        Sex = sex;
        Unit = unit;
        Value = value;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return AgeRange;
        yield return Sex;
        yield return Unit;
        yield return Value;
    }
}