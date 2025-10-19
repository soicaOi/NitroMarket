using Catalog.Application.Responses.CatalogItemResponses;

namespace Catalog.Application.Queries.CatalogItemQueries;

public record GetCatalogItemQuery : IRequest<GetCatalogItemsResult>;