using Catalog.Application.Queries.BrandQueries;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Handlers.BrandHandlers;

public class GetBrandsQueryHandler(IBrandRepository brandRepository)
    : IRequestHandler<GetBrandsQuery, GetBrandsResult>
{
    public async Task<GetBrandsResult> Handle(GetBrandsQuery query, CancellationToken cancellationToken)
    {
        IEnumerable<Brand> brandList = await brandRepository.GetAllBrandsAsync();
        GetBrandsResult result = new(brandList);
        return result;
    }
}
