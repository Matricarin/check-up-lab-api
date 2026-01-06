using FluentAssertions;

using LabApi.Application.Dtos;
using LabApi.Application.Services;
using LabApi.Domain.Entities.ClinicalTestAggregate;
using LabApi.Infrastructure.Data;
using LabApi.Integration.Fixtures;

using Microsoft.EntityFrameworkCore;

namespace LabApi.Integration;

public sealed class ClinicalTestQueryServiceTests : IClassFixture<PostgresFixture>
{
    private readonly PostgresFixture _fixture;

    public ClinicalTestQueryServiceTests(PostgresFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task GetAllClinicalTests()
    {
        await using AppDbContext context = CreateDbContext(_fixture.Container.GetConnectionString());

        context.ClinicalTests.Add(new ClinicalTest("name", "desc", 10m));

        await context.SaveChangesAsync();

        ClinicalTestQueryService service = new(context);

        IReadOnlyList<ClinicalTestDto> result = await service.GetAllAsync();

        result.Should().HaveCount(1);

        result.FirstOrDefault().Should().NotBeNull()
            .And.BeOfType<ClinicalTestDto>()
            .Subject.Name.Should().Be("name");
    }


    [Fact]
    public async Task GetClinicalTestById()
    {
        await using AppDbContext context = CreateDbContext(_fixture.Container.GetConnectionString());

        context.ClinicalTests.Add(new ClinicalTest("1", "desc", 10m));
        context.ClinicalTests.Add(new ClinicalTest("2", "desc", 10m));
        context.ClinicalTests.Add(new ClinicalTest("3", "desc", 10m));
        context.ClinicalTests.Add(new ClinicalTest("4", "desc", 10m));

        await context.SaveChangesAsync();

        ClinicalTestQueryService service = new(context);

        IReadOnlyList<ClinicalTestDto> result = await service.GetAllAsync();

        result.Should().HaveCount(4);

        result.FirstOrDefault().Should().NotBeNull()
            .And.BeOfType<ClinicalTestDto>()
            .Subject.Name.Should().Be("name");
    }

    private static AppDbContext CreateDbContext(string connectionString)
    {
        DbContextOptions<AppDbContext> options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(connectionString)
            .EnableSensitiveDataLogging()
            .Options;

        AppDbContext context = new(options);
        context.Database.Migrate();

        return context;
    }
}