using Bibosio.Interfaces;
using Bibosio.ProductsModule.Domain;
using Bibosio.ProductsModule.Domain.ValueObjects;
using Bibosio.ProductsModule.Dto;
using Bibosio.ProductsModule.Infrastructure.EventBus.Events;
using Bibosio.ProductsModule.Interfaces;
using Serilog;
using SerilogTracing;

namespace Bibosio.ProductsModule.Application
{
    internal class ProductCommandService : IProductCommandService
    {
        private readonly IProductRepository _repository;
        private readonly IEventBusProducer<ProductCreatedEvent> _eventBusProducer;
        private readonly ILogger _logger;

        public ProductCommandService(IProductRepository repository, IEventBusProducer<ProductCreatedEvent> eventBusProducer)
        {
            _repository = repository;
            _eventBusProducer = eventBusProducer;
            _logger = Log.ForContext<ProductCommandService>();
        }

        public async Task<Guid> CreateProductAsync(CreateProductDto createProductDto)
        {
            using var activity = _logger.StartActivity(nameof(CreateProductAsync));

            var id = Guid.CreateVersion7();

            var product = new Product(id) { Sku = Sku.From(createProductDto.Sku) };

            _ = await _repository.CreateAsync(product);

            await _eventBusProducer.SendMessageAsync(id.ToString(), new ProductCreatedEvent(id, product.Sku.Value));

            _logger.Debug("{Source} - Ok {Id} {@Product}", nameof(CreateProductAsync), id, product);

            return id;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            using var activity = _logger.StartActivity(nameof(UpdateProductAsync));

            var product = new Product(updateProductDto.Id) { Sku = Sku.From(updateProductDto.Sku) };

            _ = await _repository.UpdateAsync(product);

            _logger.Debug("{Source} - Ok {Id} {@Product}", nameof(UpdateProductAsync), product.Id, product);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _repository.DeleteAsync(Guid.Parse(id));
        }
    }
}
