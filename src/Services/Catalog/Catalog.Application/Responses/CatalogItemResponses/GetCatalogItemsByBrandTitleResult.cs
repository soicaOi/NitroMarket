﻿namespace Catalog.Application.Responses.CatalogItemResponses;

public record GetCatalogItemsByBrandTitleResult(IEnumerable<CatalogItem> Result);