using LabApi.Application.Dtos.ClinicalTest;
using LabApi.Application.Interfaces;
using LabApi.Domain.Entities.ClinicalTestAggregate;
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

    public async Task<IReadOnlyList<ClinicalTestResponseDto>> GetAllAsync()
    {
        return await _db.ClinicalTests
            .AsNoTracking()
            .Select(fromDb => new ClinicalTestResponseDto(fromDb.Id, fromDb.Name, fromDb.Price))
            .ToListAsync();
    }

    public async Task<ClinicalTestDetailsResponseDto?> GetByIdAsync(int id)
    {
        ClinicalTest? fromDb = await _db.ClinicalTests.AsNoTracking()
            .Include(x => x.NormalValues)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (fromDb == null)
        {
            return null;
        }

        ClinicalTestDetailsResponseDto result = new()
        {
            Name = fromDb.Name,
            Description = fromDb.Description,
            Price = fromDb.Price,
            NormalValues = fromDb.NormalValues.ToArray()
        };

        return result;
    }
}