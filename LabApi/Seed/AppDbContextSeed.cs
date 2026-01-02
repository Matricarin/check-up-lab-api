using LabApi.Domain.Entities.ClinicalTestAggregate;
using LabApi.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LabApi.Seed;

public static class AppDbContextSeed
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.ClinicalTests.AnyAsync())
        {
            return;
        }

        List<ClinicalTest> clinicalTests = FakeClinicalTestsGenerator.GenerateClinicalTestsList();

        context.ClinicalTests.AddRange(clinicalTests);

        await context.SaveChangesAsync();
    }
}