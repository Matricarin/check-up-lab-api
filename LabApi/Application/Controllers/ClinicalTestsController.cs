using LabApi.Infrastructure.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabApi.Application.Controllers;

[ApiController]
[Route("api/v1/clinical-tests")]
public sealed class ClinicalTestsController : LabBaseController
{
    public ClinicalTestsController(AppDbContext dbContext) : base(dbContext)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetAllClinicalTests()
    {
        return Ok(await _dbContext.ClinicalTests.ToListAsync());
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetClinicalTest(int id)
    {
        return Ok(await _dbContext.ClinicalTests.FindAsync(id));
    }
}