using Catalog.Application.Queries.CatalogItemQueries;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class GetCatalogItemsPaginationQueryHandler(ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<GetCatalogItemsPaginationQuery, GetCatalogItemsPaginationResult>
{
    public async Task<GetCatalogItemsPaginationResult> Handle(GetCatalogItemsPaginationQuery query, CancellationToken cancellationToken)
    {
        var catalogItems = await catalogItemRepository.GetAllCatalogItemsAsync();

        var count = catalogItems.Count();

        var items = catalogItems
            .Skip((query.PageIndex - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToList();

        var pagination = new Pagination<CatalogItem>(
            query.PageIndex,
            query.PageSize,
            count,
            items
        );

        return new GetCatalogItemsPaginationResult(pagination);
    }
}