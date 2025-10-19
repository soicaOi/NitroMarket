using Catalog.Application.Queries.BrandQueries;
using Catalog.Application.Responses.BrandResponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<GetBrandsResult>> GetBrand()
    {
        var result = await mediator.Send(new GetBrandsQuery());
        return result;
    } 
}
