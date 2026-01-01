using NerdStore.Catalog.Application.DTOs;

namespace NerdStore.Catalog.Application.Services
{
    public interface IProductAppService : IDisposable
    {
        Task<IEnumerable<ProductDto>> GetProductsByCategory(int code);
        Task<ProductDto> GetById(Guid id);
        Task<IEnumerable<ProductDto>> GetAll();
        Task<IEnumerable<CategoryDto>> GetCategories();

        Task AddProduct(ProductDto productDto);
        Task UpdateProduct(ProductDto productDto);

        Task<ProductDto> DebitStock(Guid id, int quantity);
        Task<ProductDto> ReplenishStock(Guid id, int quantity);

    }
}
