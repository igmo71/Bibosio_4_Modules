using Bibosio.Interfaces;
using Bibosio.ProductsModule.Domain;
using Bibosio.ProductsModule.Domain.ValueObjects;
using Bibosio.ProductsModule.Dto;
using Bibosio.ProductsModule.EventBus.Events;
using Bibosio.ProductsModule.Interfaces;
using Serilog;

namespace Bibosio.ProductsModule.Application
{
    public class ProductCommandServices : IProductCommandServices
    {
        private readonly IEventBusProducer<ProductCreatedEvent> _eventBusProducer;

        public ProductCommandServices(IEventBusProducer<ProductCreatedEvent> eventBusProducer)
        {
            _eventBusProducer = eventBusProducer;
        }

        public Task<Guid> CreateProduct(CreateProductDto createProductDto)
        {
            var id = Guid.CreateVersion7();

            var product = new Product(id) { Sku = Sku.From(createProductDto.Sku) };

            Log.ForContext<ProductCommandServices>().Debug("{Source} {Id} {@Product}", nameof(CreateProduct), id, product);

            _eventBusProducer.SendMessageAsync(id.ToString(), new ProductCreatedEvent(id, product.Sku.Value));

            return Task.FromResult(id);
        }

        public Task UpdateProduct(UpdateProductDto updateProductDto)
        {
            throw new NotImplementedException();
        }
    }
}
