namespace Catalog.Application.Queries.CatalogItemQueries;

public record GetCatalogItemsPaginationQuery(int PageIndex, int PageSize)
    : IRequest<GetCatalogItemsPaginationResult>;