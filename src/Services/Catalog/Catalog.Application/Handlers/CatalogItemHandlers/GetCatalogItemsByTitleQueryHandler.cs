using Catalog.Application.Queries.CatalogItemQueries;
using Catalog.Application.Responses.CatalogItemResponses;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class GetCatalogItemsByTitleQueryHandler(ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<GetCatalogItemsByTitleQuery, GetCatalogItemsByTitleResult>
{
    public async Task<GetCatalogItemsByTitleResult> Handle(GetCatalogItemsByTitleQuery query, CancellationToken cancellationToken)
    {
        var result = await catalogItemRepository.GetCatalogItemsByTitleAsync(query.Title);

        return new GetCatalogItemsByTitleResult(result);
    }
}
