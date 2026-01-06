using LabApi.Domain.Entities.ClinicalTestAggregate;

namespace LabApi.Unit.Domain;

public sealed class NormalValueFixture
{
    [Fact]
    public void ShouldThrowWhenAgeFromGreaterThenAgeTo()
    {
        Assert.Throws<ArgumentException>(() => new NormalValue(Sex.Female, 20, 10, "unit", 10m));
    }

    [Fact]
    public void ShouldThrowWhenAgeFromInvalid()
    {
        Assert.Throws<ArgumentException>(() => new NormalValue(Sex.Female, -1, 10, "unit", 10m));
    }

    [Fact]
    public void ShouldThrowWhenAgeToInvalid()
    {
        Assert.Throws<ArgumentException>(() => new NormalValue(Sex.Female, 10, -1, "unit", 10m));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void ShouldThrowWhenMeasurementUnitInvalid(string? unit)
    {
        Assert.Throws<ArgumentNullException>(() => new NormalValue(Sex.Female, 10, 20, unit, 10m));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ShouldThrowWhenValueInvalid(decimal value)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new NormalValue(Sex.Female, 10, 20, "unit", value));
    }
}