﻿namespace Catalog.Application.Responses.CatalogItemResponses;

public record GetCatalogItemsResult(IEnumerable<CatalogItem> Result);
