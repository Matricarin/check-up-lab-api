using LabApi.Domain;
using LabApi.Domain.Entities.ClinicalTestAggregate;
using LabApi.Seed;

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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<ClinicalTest>(b =>
        {
            b.HasKey(m => m.Id);

            b.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(200);

            b.Property(m => m.Price)
                .HasPrecision(10, 2);

            b.OwnsMany(m => m.NormalValues, nv =>
            {
                nv.WithOwner().HasForeignKey("ClinicalTestId");

                nv.Property<int>("Id");
                nv.HasKey("Id");

                nv.Property(m => m.Value)
                    .HasPrecision(10, 2)
                    .IsRequired();

                nv.Property(m => m.Sex)
                    .IsRequired();

                nv.OwnsOne(m => m.Unit, u =>
                {
                    u.Property(mu => mu.Code)
                        .HasColumnName("MeasurementCode")
                        .IsRequired();

                    u.Property(mu => mu.DisplayName)
                        .HasColumnName("MeasurementName")
                        .IsRequired();
                });

                nv.OwnsOne(m => m.AgeRange, r =>
                {
                    r.Property(ar => ar.From)
                        .HasColumnName("AgeFrom")
                        .IsRequired();

                    r.Property(ar => ar.To)
                        .HasColumnName("AgeTo")
                        .IsRequired();
                });
            });
        });
    }
}