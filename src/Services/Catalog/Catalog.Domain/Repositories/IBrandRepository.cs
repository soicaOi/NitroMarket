﻿namespace Catalog.Domain.Repositories;

public interface IBrandRepository
{
    Task<IEnumerable<Brand>> GetAllBrandsAsync();
}
