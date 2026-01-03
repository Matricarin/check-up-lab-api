using LabApi.Application.Dtos;
using LabApi.Application.Interfaces;
using LabApi.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LabApi.Application.Services;

public sealed class ClinicalTestQueryService : IClinicalTestQueryService
{
    private readonly AppDbContext _db;

    public ClinicalTestQueryService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<ClinicalTestDto>> GetAllAsync()
    {
        return await _db.ClinicalTests
            .AsNoTracking()
            .Select(fromDb => new ClinicalTestDto(fromDb.Name, fromDb.Price))
            .ToListAsync();
    }

    public async Task<ClinicalTestDetailsDto?> GetByIdAsync(int id)
    {
        var fromDb = await _db.ClinicalTests.FindAsync(id);

        if (fromDb == null)
        {
            return null;
        }

        var result = new ClinicalTestDetailsDto()
        {
            Name = fromDb.Name,
            Description = fromDb.Description,
            Price = fromDb.Price,
            NormalValues = fromDb.NormalValues.ToArray()
        };

        return result;
    }
}