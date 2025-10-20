using Catalog.Application.Responses.CatalogItemResponses;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Queries.CatalogItemQueries;

public class GetCatalogItemsByBrandTitleQueryHandler(ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<GetCatalogItemsByBrandTitleQuery, GetCatalogItemsByBrandTitleResult>
{
    public async Task<GetCatalogItemsByBrandTitleResult> Handle(GetCatalogItemsByBrandTitleQuery query, CancellationToken cancellationToken)
    {
        var result = await catalogItemRepository.GetCatalogItemsByBrandAsync(query.BrandTitle);

        return new GetCatalogItemsByBrandTitleResult(result);
    }
}
