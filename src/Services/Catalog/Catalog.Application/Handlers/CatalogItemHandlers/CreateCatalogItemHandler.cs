using Catalog.Application.Commands.CatalogItemCommands;
using Catalog.Application.Responses.CatalogItemResponses;
using Mapster;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class CreateCatalogItemHandler(ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<CreateCatalogItemCommand, CreateCatalogItemResult>
{
    public async Task<CreateCatalogItemResult> Handle(CreateCatalogItemCommand command, CancellationToken cancellationToken)
    {
        var catalogItem = command.CatalogItem.Adapt<CatalogItem>();
        catalogItem.Id = Guid.NewGuid();

        await catalogItemRepository.CreateCatalogItemAsync(catalogItem);
        return new CreateCatalogItemResult(catalogItem.Id);
    }
}
