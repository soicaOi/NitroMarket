namespace Catalog.Application.Responses.CatalogItemResponses;

public record GetCatalogItemsByTitleResult(IEnumerable<CatalogItem> CatalogItems);
