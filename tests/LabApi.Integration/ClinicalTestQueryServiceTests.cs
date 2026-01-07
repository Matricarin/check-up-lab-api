using FluentAssertions;

using LabApi.Application.Dtos.ClinicalTest;
using LabApi.Application.Services;
using LabApi.Domain.Entities.ClinicalTestAggregate;
using LabApi.Infrastructure.Data;
using LabApi.Integration.Fixtures;

using Microsoft.EntityFrameworkCore;

namespace LabApi.Integration;

[Collection("Postgres")]
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
        using AppDbContext context = CreateContext();
        Seed(context);

        ClinicalTestQueryService service = new(context);

        IReadOnlyList<ClinicalTestResponseDto> result = await service.GetAllAsync();

        result.Should().HaveCount(4);
    }

    [Fact]
    public async Task GetClinicalTestById()
    {
        using AppDbContext context = CreateContext();
        Seed(context);

        ClinicalTestQueryService service = new(context);

        ClinicalTestResponseDto second =
            (await service.GetAllAsync()).Single(x => x.Name == "2");

        ClinicalTestDetailsResponseDto? details =
            await service.GetByIdAsync(second.Id);

        details.Should().NotBeNull();
        details!.Name.Should().Be("2");
    }

    [Fact]
    public async Task GetClinicalTestByIdReturnNull()
    {
        using AppDbContext context = CreateContext();
        Seed(context);

        ClinicalTestQueryService service = new(context);

        ClinicalTestDetailsResponseDto? result = await service.GetByIdAsync(9999);

        result.Should().BeNull();
    }

    private AppDbContext CreateContext()
    {
        return CreateDbContext(_fixture.Container.GetConnectionString());
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

    private static void Seed(AppDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.Migrate();

        context.ClinicalTests.AddRange(
            new ClinicalTest("1", "desc", 10m),
            new ClinicalTest("2", "desc", 10m),
            new ClinicalTest("3", "desc", 10m),
            new ClinicalTest("4", "desc", 10m)
        );

        context.SaveChanges();
    }
}