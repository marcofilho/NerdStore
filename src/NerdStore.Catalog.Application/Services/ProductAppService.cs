using AutoMapper;
using NerdStore.Catalog.Application.DTOs;
using NerdStore.Catalog.Domain;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalog.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IStockService _stockService;

        public ProductAppService(IProductRepository productRepository, IMapper mapper, IStockService stockService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _stockService = stockService;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductDto>>(await _productRepository.GetAllAsync());
        }

        public async Task<ProductDto> GetById(Guid id)
        {
            return _mapper.Map<ProductDto>(await _productRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(await _productRepository.GetCategoriesAsync());
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByCategory(int code)
        {
            return _mapper.Map<IEnumerable<ProductDto>>(await _productRepository.GetByCategoryAsync(code));
        }

        public async Task AddProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _productRepository.Add(product);

            await _productRepository.UnitOfWork.Commit();
        }

        public async Task UpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _productRepository.Update(product);

            await _productRepository.UnitOfWork.Commit();
        }

        public async Task<ProductDto> DebitStock(Guid id, int quantity)
        {
            if (!await _stockService.DebitStock(id, quantity))
            {
                throw new DomainException("Failed to debit stock");
            }

            return _mapper.Map<ProductDto>(await _productRepository.GetByIdAsync(id));
        }

        public async Task<ProductDto> ReplenishStock(Guid id, int quantity)
        {
            if (!await _stockService.ReplenishStock(id, quantity))
            {
                throw new DomainException("Failed to replenish stock");
            }

            return _mapper.Map<ProductDto>(await _productRepository.GetByIdAsync(id));
        }

        public void Dispose()
        {
            _productRepository?.Dispose();
        }
    }
}
