namespace LabApi.Domain.Entities.ClinicalTestAggregate;

public sealed class MeasurementUnit : ValueObject
{
    public string Code { get; private set; }
    public string DisplayName { get; private set; }

    private MeasurementUnit(){ }

    public static MeasurementUnit Milliliters => new("ml", "Milliliters");
    public static readonly MeasurementUnit MgPerDl = new("mg/dL", "Milligrams per deciliter");
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