using NerdStore.Catalog.Domain.Events;
using NerdStore.Core.Bus;

namespace NerdStore.Catalog.Domain
{
    public class StockService : IStockService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediatrHandler _bus;

        public StockService(IProductRepository productRepository, IMediatrHandler bus)
        {
            _productRepository = productRepository;
            _bus = bus;
        }

        public async Task<bool> DebitStock(Guid productId, int quantity)
        {
            var product = await _productRepository.GetByIdAsync(productId);

            if (product is null) return false;

            if (!product.StockAvailable(quantity)) return false;

            product.DecreaseStock(quantity);

            //TODO: Move magic number to config
            if (product.StockAmount < 10)
            {
                await _bus.PublishEvent(new ProductBelowMinimumStockEvent(product.Id, product.StockAmount));
            }

            _productRepository.Update(product);
            return await _productRepository.UnitOfWork.Commit();
        }

        public async Task<bool> ReplenishStock(Guid productId, int quantity)
        {
            var product = await _productRepository.GetByIdAsync(productId);

            if (product is null) return false;

            product.IncreaseStock(quantity);

            _productRepository.Update(product);
            return await _productRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}
