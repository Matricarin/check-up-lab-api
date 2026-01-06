using Bogus;

using LabApi.Domain.Entities.ClinicalTestAggregate;

namespace LabApi.Infrastructure.Seed;

public static class FakeClinicalTestsGenerator
{
    public static List<ClinicalTest> GenerateClinicalTestsList(int count = 10)
    {
        var faker = new Faker("ru");

        var result = new List<ClinicalTest>();

        for (int i = 0; i < count; i++)
        {
            var clinicalTest = new ClinicalTest(
                name: faker.Commerce.ProductName(),
                description: faker.Commerce.ProductDescription(),
                price: faker.Random.Decimal(100, 5000)
            );

            AddNormalValues(clinicalTest, faker);

            result.Add(clinicalTest);
        }

        return result;
    }

    private static void AddNormalValues(ClinicalTest clinicalTest, Faker faker)
    {
        var ageRanges = new[]
        {
            (0, 12),
            (13, 18),
            (19, 60),
            (61, 120)
        };

        foreach (var sex in Enum.GetValues<Sex>())
        {
            foreach (var ageRange in ageRanges)
            {
                var normalValue = new NormalValue(
                    sex,
                    ageRange.Item1,
                    ageRange.Item2,
                    "ml",
                    faker.Random.Decimal(3, 15)
                );

                clinicalTest.AddNormalValue(normalValue);
            }
        }
    }
}