namespace Catalog.Infrastructure.Repositories;

public class CatalogRepository (IDocumentSession session)
    : IBrandRepository, ICategoryRepository, ICatalogItemRepository
{
    // IBrandRepository
    public async Task<IEnumerable<Brand>> GetAllBrandsAsync()
    {
        return await session.Query<Brand>().ToListAsync();
    }

    // ICategoryRepository
    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await session.Query<Category>().ToListAsync();
    }

    // ICatalogItemRepository
    public async Task<IEnumerable<CatalogItem>> GetAllCatalogItemsAsync()
    {
        return await session.Query<CatalogItem>().ToListAsync();
    }

    public async Task<CatalogItem?> GetCatalogItemAsync(Guid id)
    {
        return await session.LoadAsync<CatalogItem>(id);
    }

    public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByBrandAsync(string brandTitle)
    {
        return await session.Query<CatalogItem>()
            .Where(i => i.Brand != null
            && !string.IsNullOrEmpty(i.Brand.Title)
            && i.Brand.Title.Contains(brandTitle, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
    }

    public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByTitleAsync(string title)
    {
        return await session.Query<CatalogItem>()
            .Where(i => !string.IsNullOrEmpty(i.Title)
                && i.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
            .ToListAsync();
    }

    public async Task<CatalogItem> CreateCatalogItemAsync(CatalogItem item)
    {
        session.Store(item);
        await session.SaveChangesAsync();
        return item;
    }

    public async Task<bool> DeleteCatalogItemAsync(Guid id)
    {
        session.Delete<CatalogItem>(id);
        await session.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateCatalogItemAsync(CatalogItem item)
    {
        session.Store(item);
        await session.SaveChangesAsync();
        return true;
    }
}
    