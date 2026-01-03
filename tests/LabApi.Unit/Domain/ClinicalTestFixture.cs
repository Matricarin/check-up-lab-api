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

    [Fact]
    public void ShouldThrowWhenDuplicateExist()
    {
        var ct = new ClinicalTest("name", "desc", 10);
        var normal = new NormalValue(Sex.Male, 10, 30, "ml", 20.3m);
        ct.AddNormalValue(normal);

        Assert.Throws<InvalidOperationException>(() => ct.AddNormalValue(normal));
    }

    [Fact]
    public void ShouldRemoveNormalValue()
    {
        throw new NotImplementedException();
    }
}