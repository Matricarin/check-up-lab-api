using LabApi.Infrastructure.Data;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabApi.Application.Controllers
{
    [ApiController]
    public class LabBaseController : ControllerBase
    {
        protected readonly AppDbContext _dbContext;

        public LabBaseController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
