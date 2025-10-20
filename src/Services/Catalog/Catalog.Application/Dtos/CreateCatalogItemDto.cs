namespace Catalog.Application.Dtos;

public record CreateCatalogItemDto(
    string? Title,
    string? ShortDescription,
    string? FullDescription,
    string? ImageUrl,
    BrandDto? Brand,
    CategoryDto? Category,
    decimal Price
);