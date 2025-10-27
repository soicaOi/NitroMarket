using Catalog.Application.Commands.CatalogItemCommands;
using Mapster;

namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class UpdateCatalogItemCommangHandler(ICatalogItemRepository catalogItemRepository, IBrandRepository brandRepository, ICategoryRepository categoryRepository)
    : IRequestHandler<UpdateCatalogItemCommand, UpdateCatalogItemResult>
{
    public async Task<UpdateCatalogItemResult> Handle(UpdateCatalogItemCommand command, CancellationToken cancellationToken)
    {
        var dto = command.CatalogItem;

        var currentItem = await catalogItemRepository.GetCatalogItemAsync(dto.Id);

        if (currentItem is null) return new UpdateCatalogItemResult(false, "Некорректный идентификатор товара");

        if (dto.Brand is not null
            && await brandRepository.GetBrandAsync(dto.Brand.Id) is null)
        {
            return new UpdateCatalogItemResult(false, "Указанного бренда не существует");
        }

        if (dto.Category is not null && await categoryRepository.GetCategoryAsync(dto.Category.Id) is null)
        {
            return new UpdateCatalogItemResult(false, "Указанной категории не существует");
        }

        var catalogItem = dto.Adapt<CatalogItem>();

        var isSuccess = await catalogItemRepository.UpdateCatalogItemAsync(catalogItem);
        return new UpdateCatalogItemResult(isSuccess, "Успешное обновление товара");
    }
}