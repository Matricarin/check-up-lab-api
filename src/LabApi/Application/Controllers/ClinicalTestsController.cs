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
        //  TODO: improve controller logic
        return Ok(await _dbContext.ClinicalTests.ToListAsync());
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetClinicalTest(int id)
    {
        //  TODO: improve controller logic
        return Ok(await _dbContext.ClinicalTests.FindAsync(id));
    }

    //  TODO: define post method for creation clinical test by admin
    //  TODO: define dto for clinical test creation

    //  TODO: define put method for updating clinical test by admin
    //  TODO: define dto for clinical test update

    //  TODO: define delete method for deleting clinical test by admin
    //  TODO: define dto for clinical test delete
}