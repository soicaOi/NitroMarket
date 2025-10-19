using Asp.Versioning;

namespace Catalog.API.Controllers;

[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ApiController : ControllerBase
{
    private IMediator? mediator;

    protected IMediator Mediator =>
        mediator ??= HttpContext.RequestServices.GetService<IMediator>()
            ?? throw new InvalidOperationException("Служба IMediator недоступна");
}
