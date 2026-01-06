using FluentAssertions;

using LabApi.Application.Dtos;
using LabApi.Application.Interfaces;
using LabApi.Application.Services;
using LabApi.Domain.Entities.ClinicalTestAggregate;
using LabApi.Infrastructure.Data;
using LabApi.Integration.Fixtures;

using Microsoft.EntityFrameworkCore;

namespace LabApi.Integration;

public sealed class ClinicalTestQueryServiceTests : IClassFixture<PostgresFixture>
{
    private readonly PostgresFixture _fixture;
    private readonly IClinicalTestQueryService _service;

    public ClinicalTestQueryServiceTests(PostgresFixture fixture)
    {
        _fixture = fixture;
        using AppDbContext context = CreateDbContext(_fixture.Container.GetConnectionString());

        context.ClinicalTests.Add(new ClinicalTest("1", "desc", 10m));
        context.ClinicalTests.Add(new ClinicalTest("2", "desc", 10m));
        context.ClinicalTests.Add(new ClinicalTest("3", "desc", 10m));
        context.ClinicalTests.Add(new ClinicalTest("4", "desc", 10m));

        context.SaveChanges();

        _service = new ClinicalTestQueryService(context);
    }

    [Fact]
    public async Task GetAllClinicalTests()
    {
        await using AppDbContext context = CreateDbContext(_fixture.Container.GetConnectionString());

        IReadOnlyList<ClinicalTestDto> result = await _service.GetAllAsync();

        result.Should().HaveCount(4);
    }

    [Fact]
    public async Task GetClinicalTestById()
    {
        IReadOnlyList<ClinicalTestDto> resultFromDb = await _service.GetAllAsync();

        ClinicalTestDto? secondItem = resultFromDb.FirstOrDefault(n => n.Name == "2");

        secondItem.Should().NotBeNull();

        ClinicalTestDetailsDto? secondFromDb = await _service.GetByIdAsync(secondItem.Id);

        secondFromDb.Should().NotBeNull();

        secondFromDb.Should().BeOfType<ClinicalTestDetailsDto>()
            .Subject.Name.Should().Be("2");
    }

    [Fact]
    public async Task GetClinicalTestByIdReturnNull()
    {
        ClinicalTestDetailsDto? secondFromDb = await _service.GetByIdAsync(10000);

        secondFromDb.Should().BeNull();
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