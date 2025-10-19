using Catalog.Application.Queries.CatalogItemQueries;
using Catalog.Application.Responses.CatalogItemResponses;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class GetCatalogItemsQueryHandler(ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<GetCatalogItemQuery, GetCatalogItemsResult>
{
    public async Task<GetCatalogItemsResult> Handle(GetCatalogItemQuery request, CancellationToken cancellationToken)
    {
        var catalogItems = await catalogItemRepository.GetAllCatalogItemsAsync();
        
        return new GetCatalogItemsResult(catalogItems);
    }
}
