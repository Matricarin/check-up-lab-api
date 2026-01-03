using LabApi.Domain.Entities.ClinicalTestAggregate;

namespace LabApi.Unit.Domain;

public sealed class ClinicalTestFixture 
{
    [Theory]
    [InlineData(null, "desc")]
    [InlineData("", "desc")]
    [InlineData("name", null)]
    [InlineData("name", "")]
    public void ConstructorThrowArgumentNullException(string? name, string? description)
    {
        Assert.Throws<ArgumentNullException>(() => new ClinicalTest(name, description, 1));
    }

    [Theory]
    [InlineData(-100)]
    public void ConstructorThrowArgumentExceptionByInvalidPrice(decimal price)
    {
        Assert.Throws<ArgumentException>(() => new ClinicalTest("name", "desc", price));
    }


}