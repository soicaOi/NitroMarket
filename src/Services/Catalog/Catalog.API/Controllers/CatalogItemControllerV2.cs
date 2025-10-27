using Asp.Versioning;
using Catalog.Application.Queries.CatalogItemQueries;
using Catalog.Application.Responses.CatalogItemResponses;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Catalog.API.Controllers;

[ApiVersion("2")]
[ApiExplorerSettings(GroupName = "v2")]
[Route("api/v{version:apiVersion}/CatalogItem")]
public class CatalogItemControllerV2 : ApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(GetCatalogItemsPaginationResult), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Tags = new[] { "CatalogItemControllerV2" })]
    public async Task<ActionResult<GetCatalogItemsPaginationResult>> Get([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 5)
    {
        var result = await Mediator.Send(new GetCatalogItemsPaginationQuery(pageIndex, pageSize));

        if (result.Result is null || !result.Result.Items.Any())
        {
            return NotFound($"Нет товаров");
        }

        return Ok(result);
    }
}
