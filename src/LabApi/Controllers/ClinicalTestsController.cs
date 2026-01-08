using LabApi.Application.Dtos.ClinicalTest;
using LabApi.Application.Interfaces;
using LabApi.Shared;

using Microsoft.AspNetCore.Authorization;
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
    [Produces("application/json")]
    [ProducesResponseType(typeof(IReadOnlyList<ClinicalTestResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Authorize(Policy = ApiPermissions.ClinicalTestsRead)]
    public async Task<ActionResult<IReadOnlyList<ClinicalTestResponseDto>>> GetAll()
    {
        IReadOnlyList<ClinicalTestResponseDto> resultList = await _queryService.GetAllAsync();

        if (!resultList.Any())
        {
            return NotFound();
        }

        return Ok(resultList);
    }

    [HttpGet("{id:int}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ClinicalTestDetailsResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Authorize(Policy = ApiPermissions.ClinicalTestsRead)]
    public async Task<ActionResult<ClinicalTestDetailsResponseDto>> GetById(int id)
    {
        ClinicalTestDetailsResponseDto? result = await _queryService.GetByIdAsync(id);

        return result == null ? NotFound() : Ok(result);
    }
}