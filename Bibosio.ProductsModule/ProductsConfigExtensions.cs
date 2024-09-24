using Bibosio.ProductsModule.EventBus.Kafka;
using Bibosio.ProductsModule.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bibosio.ProductsModule
{
    public static class ProductsConfigExtensions
    {
        public static IServiceCollection AddProductsModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IEventBusProducer, KafkaProducerService>();

            services.AddScoped<IProductCommandServices, IProductCommandServices>();

            return services;
        }
    }
}
