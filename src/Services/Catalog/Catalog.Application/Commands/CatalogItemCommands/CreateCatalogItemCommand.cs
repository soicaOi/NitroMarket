namespace Catalog.Application.Commands.CatalogItemCommands;

public record CreateCatalogItemCommand(
    CreateCatalogItemDto CatalogItem
) : IRequest<CreateCatalogItemResult>;