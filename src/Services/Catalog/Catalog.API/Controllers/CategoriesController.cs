using Catalog.Application.Queries.CategoryQueries;
using Catalog.Application.Responses.CategoryResponses;

namespace Catalog.API.Controllers;
public class CategoriesController : ApiController
{
    [HttpGet]
    public async Task<ActionResult<GetCategoriesResult>> GetCategory()
    {
        var result = await Mediator.Send(new GetCategoriesQuery());

        return Ok(result);
    }
}