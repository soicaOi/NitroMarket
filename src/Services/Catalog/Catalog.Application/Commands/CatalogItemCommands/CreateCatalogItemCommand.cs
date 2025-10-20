using Catalog.Application.Responses.CatalogItemResponses;

namespace Catalog.Application.Commands.CatalogItemCommands;

public record CreateCatalogItemCommand(
    CreateCatalogItemDto Dto
) : IRequest<CreateCatalogItemResult>;