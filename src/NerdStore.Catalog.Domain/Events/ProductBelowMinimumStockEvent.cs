using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalog.Domain.Events
{
    public class ProductBelowMinimumStockEvent : DomainEvent
    {
        public int RemainingStock { get; private set; }

        public ProductBelowMinimumStockEvent(Guid aggregateId, int remainingStock) : base(aggregateId)
        {
            RemainingStock = remainingStock;
        }
    }
}
