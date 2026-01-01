using MediatR;

namespace NerdStore.Catalog.Domain.Events
{
    public class ProductEventHandler : INotificationHandler<ProductBelowMinimumStockEvent>
    {
        private readonly IProductRepository _productRepository;

        public ProductEventHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(ProductBelowMinimumStockEvent notification, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(notification.AggregateId);
        }
    }
}
