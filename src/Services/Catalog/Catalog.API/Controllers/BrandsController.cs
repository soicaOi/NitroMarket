namespace Catalog.API.Controllers;

public class BrandsController : ApiController
{
    [HttpGet]
    public async Task<ActionResult<GetBrandsResult>> GetBrand()
    {
        var result = await Mediator.Send(new GetBrandsQuery());
        return Ok(result);
    } 
}
