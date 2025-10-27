namespace Catalog.Application.Responses.CatalogItemResponses;

public record GetCatalogItemsPaginationResult(Pagination<CatalogItem> Result);
