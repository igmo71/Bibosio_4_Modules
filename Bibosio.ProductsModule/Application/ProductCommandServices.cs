using Bibosio.Interfaces;
using Bibosio.ProductsModule.Domain;
using Bibosio.ProductsModule.Domain.ValueObjects;
using Bibosio.ProductsModule.Dto;
using Bibosio.ProductsModule.EventBus.Events;
using Bibosio.ProductsModule.Infrastructure.Data;
using Bibosio.ProductsModule.Interfaces;
using Serilog;
using SerilogTracing;

namespace Bibosio.ProductsModule.Application
{
    internal class ProductCommandServices : IProductCommandServices
    {
        private readonly ProductsDbContext _dbContext;
        private readonly IEventBusProducer<ProductCreatedEvent> _eventBusProducer;
        private readonly ILogger _logger;

        public ProductCommandServices(ProductsDbContext dbContext, IEventBusProducer<ProductCreatedEvent> eventBusProducer)
        {
            _dbContext = dbContext;
            _eventBusProducer = eventBusProducer;
            _logger = Log.ForContext<ProductCommandServices>();
        }

        public async Task<Guid> CreateProductAsync(CreateProductDto createProductDto)
        {
            using var activity = _logger.StartActivity(nameof(CreateProductAsync));

            var id = Guid.CreateVersion7();

            var product = new Product(id) { Sku = Sku.From(createProductDto.Sku) };

            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            await _eventBusProducer.SendMessageAsync(id.ToString(), new ProductCreatedEvent(id, product.Sku.Value));

            _logger.Debug("{Source} - Ok {Id} {@Product}", nameof(CreateProductAsync), id, product);

            return id;
        }

        public Task UpdateProduct(UpdateProductDto updateProductDto)
        {
            throw new NotImplementedException();
        }
    }
}
