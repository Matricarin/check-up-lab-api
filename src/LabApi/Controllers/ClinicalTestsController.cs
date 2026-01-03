using Microsoft.AspNetCore.Mvc;

namespace LabApi.Controllers;

[ApiController]
[Route("api/v1/clinical-tests")]
public sealed class ClinicalTestsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        throw new NotImplementedException();
    }
    
    //  TODO: define post method for creation clinical test by admin
    //  TODO: define dto for clinical test creation

    //  TODO: define put method for updating clinical test by admin
    //  TODO: define dto for clinical test update

    //  TODO: define delete method for deleting clinical test by admin
    //  TODO: define dto for clinical test delete
}