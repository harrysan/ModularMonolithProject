namespace Catalog.Products.EventsHandlers
{
    public class ProductPriceChangedEventHandler
        (ILogger<ProductPriceChangedEventHandler> logger)
        : INotificationHandler<ProductPriceChangedEvent>
    {
        public Task Handle(ProductPriceChangedEvent notification, CancellationToken cancellationToken)
        {
            // Publish product price changed integration event for update basket prices
            logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
