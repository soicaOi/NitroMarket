﻿namespace Catalog.Application.Responses.CategoryResponses;

public record GetCategoriesResult(IEnumerable<Category> Categories);