using Catalog.Application.Queries.CatalogItemQueries;
using Catalog.Application.Responses.CatalogItemResponses;
using System.Net;

namespace Catalog.API.Controllers;

public class CategoryItemsController : ApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(GetCatalogItemsResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemsResult>> GetCategoryItem()
    {
        var result = await Mediator.Send(new GetCatalogItemsQuery());

        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetCatalogItemByIdResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemByIdResult>> GetCategoryItemById(Guid id)
    {
        var result = await Mediator.Send(new GetCatalogItemByIdQuery(id));

        if (result.CatalogItem is null)
        {
            return NotFound($"Товар с таким идентификатором {id} не найден");
        }

        return Ok(result);
    }
}
