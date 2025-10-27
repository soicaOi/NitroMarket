namespace Catalog.Application.Commands.CatalogItemCommands;

public record UpdateCatalogItemCommand(UpdateCatalogItemDto CatalogItem)
    : IRequest<UpdateCatalogItemResult>;
