using FluentAssertions;

using LabApi.Domain.Entities.ClinicalTestAggregate;

namespace LabApi.Unit.Domain;

public sealed class ClinicalTestFixture
{
    [Theory]
    [InlineData(-100)]
    [InlineData(-1)]
    public void ConstructorThrowArgumentExceptionByInvalidPrice(decimal price)
    {
        Assert.Throws<ArgumentException>(() => new ClinicalTest("name", "desc", price));
    }

    [Theory]
    [InlineData(null, "desc")]
    [InlineData("", "desc")]
    [InlineData("name", null)]
    [InlineData("name", "")]
    public void ConstructorThrowArgumentNullException(string? name, string? description)
    {
        Assert.Throws<ArgumentNullException>(() => new ClinicalTest(name, description, 1));
    }

    [Fact]
    public void ShouldRemoveNormalValue()
    {
        ClinicalTest ct = new("name", "desc", 10);
        NormalValue normal = new(Sex.Male, 10, 30, "ml", 20.3m);
        ct.AddNormalValue(normal);
        ct.RemoveNormalValue(normal);

        ct.NormalValues.Should().BeEmpty();
    }

    [Fact]
    public void ShouldThrowWhenDuplicateExist()
    {
        ClinicalTest ct = new("name", "desc", 10);
        NormalValue normal = new(Sex.Male, 10, 30, "ml", 20.3m);
        ct.AddNormalValue(normal);

        Assert.Throws<InvalidOperationException>(() => ct.AddNormalValue(normal));
    }

    [Fact]
    public void ShouldThrowWhenRemoveNotExistedValue()
    {
        ClinicalTest ct = new("name", "desc", 10);

        Assert.Throws<InvalidOperationException>(() =>
            ct.RemoveNormalValue(new NormalValue(Sex.Female, 10, 20, "ml", 10m)));
    }
}