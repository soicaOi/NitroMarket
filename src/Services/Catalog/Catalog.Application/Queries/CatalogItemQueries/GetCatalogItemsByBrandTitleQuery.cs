using Catalog.Application.Responses.CatalogItemResponses;

namespace Catalog.Application.Queries.CatalogItemQueries;

public record GetCatalogItemsByBrandTitleQuery(string BrandTitle)
    : IRequest<GetCatalogItemsByBrandTitleResult>;