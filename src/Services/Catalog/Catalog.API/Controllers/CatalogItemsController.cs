using Catalog.Application.Commands.CatalogItemCommands;
using Catalog.Application.Dtos;
using Catalog.Application.Queries.CatalogItemQueries;
using Catalog.Application.Responses.CatalogItemResponses;
using System.Net;

namespace Catalog.API.Controllers;

public class CatalogItemsController : ApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(GetCatalogItemsResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemsResult>> Get()
    {
        var result = await Mediator.Send(new GetCatalogItemsQuery());

        if (result.Result is null || !result.Result.Any())
        {
            return NotFound($"Нет товаров");
        }

        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetCatalogItemByIdResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemByIdResult>> GetCatalogItemById(Guid id)
    {
        var result = await Mediator.Send(new GetCatalogItemByIdQuery(id));

        if (result.Result is null)
        {
            return NotFound($"Товар с таким идентификатором [{id}] не найден");
        }

        return Ok(result);
    }

    [HttpGet("title/{catalogItemTitle}")]
    [ProducesResponseType(typeof(GetCatalogItemsByTitleResult), (int)HttpStatusCode.OK)]

    public async Task<ActionResult<GetCatalogItemByIdResult>> GetByTitle(string catalogItemTitle)
    {
        var result = await Mediator.Send(new GetCatalogItemsByTitleQuery(catalogItemTitle));

        if (result.Result is null || !result.Result.Any())
        {
            return NotFound($"Товары с таким названием [{catalogItemTitle}] не найдены");
        }

        return Ok(result);
    }

    [HttpGet("brand/{brandTitle}")]
    [ProducesResponseType(typeof(GetCatalogItemByIdResult), (int)HttpStatusCode.OK)]

    public async Task<ActionResult<GetCatalogItemByIdResult>> GetByBrandTitle(string brandTitle)
    {
        var result = await Mediator.Send(new GetCatalogItemsByBrandTitleQuery(brandTitle));

        if (result.Result is null || !result.Result.Any())
        {
            return NotFound($"Товары с таким брендом [{brandTitle}] не найдены");
        }

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateCatalogItemResult), StatusCodes.Status201Created)]
    public async Task<ActionResult<CreateCatalogItemResult>> CreateCatalogItem([FromBody] CreateCatalogItemDto dto)
    {
        var result = await Mediator.Send(new CreateCatalogItemCommand(dto));

        return CreatedAtAction(
            nameof(GetCatalogItemById),
            new { id = result.Id },
            result
        );
    }
}
