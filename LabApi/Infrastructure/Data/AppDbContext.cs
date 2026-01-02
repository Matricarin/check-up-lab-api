using LabApi.Core.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LabApi.Infrastructure.Data;

public class AppDbContext : IdentityDbContext
{
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<ClinicalTest> ClinicalTests { get; set; }
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.ConfigureWarnings(warning =>
            warning.Ignore(RelationalEventId.PendingModelChangesWarning));
    }
}