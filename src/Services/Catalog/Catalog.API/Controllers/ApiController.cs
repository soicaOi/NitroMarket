namespace Catalog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApiController : ControllerBase
{
    private IMediator? mediator;

    protected IMediator Mediator =>
        mediator ??= HttpContext.RequestServices.GetService<IMediator>()
            ?? throw new InvalidOperationException("Служба IMediator недоступна");
}
