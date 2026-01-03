using LabApi.Infrastructure.Data;

using Microsoft.AspNetCore.Mvc;

namespace LabApi.Application.Controllers;

public class LabBaseController : ControllerBase
{
    protected readonly AppDbContext _dbContext;

    public LabBaseController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}