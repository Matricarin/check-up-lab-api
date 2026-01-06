using Testcontainers.PostgreSql;

namespace LabApi.Integration.Fixtures;

[CollectionDefinition("Postgres")]
public sealed class PostgresFixture : IAsyncLifetime
{
    public PostgreSqlContainer Container { get; } = new PostgreSqlBuilder()
        .WithDatabase("lab-api-test")
        .WithUsername("postgres")
        .WithPassword("postgres")
        .Build();

    public async Task DisposeAsync()
    {
        await Container.DisposeAsync();
    }

    public async Task InitializeAsync()
    {
        await Container.StartAsync();
    }
}