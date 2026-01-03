using Microsoft.AspNetCore.Mvc;
using LabApi.Application.Dtos;
namespace LabApi.Controllers;

[ApiController]
[Route("api/v1/clinical-tests")]
public sealed class ClinicalTestsController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ClinicalTestDto>>> GetAll()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ClinicalTestDetailsDto>> GetById(int id)
    {
        throw new NotImplementedException();
    }
}
