﻿namespace Catalog.Domain.Repositories;

public interface ICatalogItemRepository
{
    Task<CatalogItem> CreateCatalogItemAsync(CatalogItem item);
    Task<IEnumerable<CatalogItem>> GetAllCatalogItemsAsync();
    Task<CatalogItem?> GetCatalogItemAsync(Guid id);
    Task<IEnumerable<CatalogItem>> GetCatalogItemsByTitleAsync(string title);
    Task<IEnumerable<CatalogItem>> GetCatalogItemsByBrandAsync(string brandTitle);
    Task<bool> UpdateCatalogItemAsync(CatalogItem item);
    Task<bool> DeleteCatalogItemAsync(Guid id);
}
