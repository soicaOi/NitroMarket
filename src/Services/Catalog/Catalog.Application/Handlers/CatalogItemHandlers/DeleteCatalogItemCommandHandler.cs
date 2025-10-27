namespace Catalog.Application.Handlers.CatalogItemHandlers;

public class DeleteCatalogItemCommandHandler(ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<DeleteCatalogItemCommand, DeleteCatalogItemResult>
{
    public async Task<DeleteCatalogItemResult> Handle(DeleteCatalogItemCommand command, CancellationToken cancellationToken)
    {
        if (await catalogItemRepository.GetCatalogItemAsync(command.Id) is null)
        {
            return new DeleteCatalogItemResult(false, "Такого товара не существует");
        }

        var result = await catalogItemRepository.DeleteCatalogItemAsync(command.Id);

        if (!result)
        {
            return new DeleteCatalogItemResult(false, "Ошибка при удалении товара");
        }
            
        return new DeleteCatalogItemResult(result, "Успешное удаление товара");
    }
}
