namespace LabApi.Domain.Entities.ClinicalTestAggregate;

public sealed class MeasurementUnit : ValueObject
{
    public string Code { get; }
    public string DisplayName { get; }

    private MeasurementUnit(){ }

    public static MeasurementUnit Milliliters => new("ml", "Milliliters");

    private MeasurementUnit(string code, string displayName)
    {
        Code = code;
        DisplayName = displayName;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
        yield return DisplayName;
    }
}