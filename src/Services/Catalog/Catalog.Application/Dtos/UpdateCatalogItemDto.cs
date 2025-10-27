namespace Catalog.Application.Dtos;

public record UpdateCatalogItemDto(
    Guid Id,
    string? Title,
    string? ShortDescription,
    string? FullDescription,
    string? ImageUrl,
    BrandDto? Brand,
    CategoryDto? Category,
    decimal Price
);