using LabApi.Application.Dtos;
using LabApi.Application.Interfaces;
using LabApi.Shared;

using Microsoft.AspNetCore.Mvc;

namespace LabApi.Controllers;

[ApiController]
[Route($"api/{ApiRoutes.Version1}/clinical-tests")]
public sealed class ClinicalTestsController : ControllerBase
{
    private readonly IClinicalTestQueryService _queryService;

    public ClinicalTestsController(IClinicalTestQueryService queryService)
    {
        _queryService = queryService;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ClinicalTestDto>>> GetAll()
    {
        IReadOnlyList<ClinicalTestDto> resultList = await _queryService.GetAllAsync();

        if (!resultList.Any())
        {
            return NotFound();
        }

        return Ok(resultList);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ClinicalTestDetailsDto>> GetById(int id)
    {
        ClinicalTestDetailsDto? result = await _queryService.GetByIdAsync(id);

        return result == null ? NotFound() : Ok(result);
    }
}