using Microsoft.AspNetCore.Mvc;
using LabApi.Application.Dtos;
using LabApi.Shared;

namespace LabApi.Controllers;

[ApiController]
[Route($"api/{ApiRoutes.Version1}/clinical-tests")]
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
