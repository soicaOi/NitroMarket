namespace Catalog.Domain.Repositories;

public interface IBrandRepository
{
    Task<IEnumerable<Brand>> GetAllBrandsAsync();
    Task<Brand?> GetBrandAsync(Guid id);
}
