using Catalog.Application.Responses.CatalogItemResponses;

namespace Catalog.API.Controllers;

public class CategoryItemsController : ApiController
{
    [HttpGet]
    public async Task<ActionResult<GetCatalogItemsResult>> GetCategoryItem()
    {
        var result = await Mediator.Send(new GetBrandsQuery());

        return Ok(result);
    }
}
