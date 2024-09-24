using Bibosio.ProductsModule.Domain;
using Bibosio.ProductsModule.Domain.ValueObjects;
using Bibosio.ProductsModule.Dto;
using Bibosio.ProductsModule.Interfaces;
using Serilog;

namespace Bibosio.ProductsModule.Application
{
    public class ProductCommandServices : IProductCommandServices
    {
        private readonly IEventBusProducer<Product> _eventBusProducer;

        public ProductCommandServices(IEventBusProducer<Product> eventBusProducer)
        {
            _eventBusProducer = eventBusProducer;
        }

        public Task<Guid> CreateProduct(CreateProductDto createProductDto)
        {
            var id = Guid.CreateVersion7();

            var product = new Product(id) { SKU = SKU.From(createProductDto.SKU) };

            Log.Debug("{Source} {Id} {@Product}", nameof(CreateProduct), id, product);

            _eventBusProducer.SendMessageAsync(id.ToString(), product);

            return Task.FromResult(id);
        }

        public Task UpdateProduct(UpdateProductDto updateProductDto)
        {
            throw new NotImplementedException();
        }
    }
}
