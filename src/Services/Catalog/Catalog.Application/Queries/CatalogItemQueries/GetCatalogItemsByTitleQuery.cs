using Catalog.Application.Responses.CatalogItemResponses;

namespace Catalog.Application.Queries.CatalogItemQueries;

public record GetCatalogItemsByTitleQuery(string Title) : IRequest<GetCatalogItemsByTitleResult>;
