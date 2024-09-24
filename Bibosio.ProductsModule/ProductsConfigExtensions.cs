using Bibosio.Interfaces;
using Bibosio.ProductsModule.Application;
using Bibosio.ProductsModule.Endpoints;
using Bibosio.ProductsModule.EventBus.Events;
using Bibosio.ProductsModule.EventBus.Kafka;
using Bibosio.ProductsModule.Interfaces;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bibosio.ProductsModule
{
    public static class ProductsConfigExtensions
    {
        public static IServiceCollection AddProductsModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductCommandServices, ProductCommandServices>();
         
            services.AddSingleton<IEventBusProducer<ProductCreatedEvent>, KafkaProductCreatedProducer>();

            services.AddHostedService<KafkaProductCreatedConsumer>();

            return services;
        }

        public static IEndpointRouteBuilder MapProductModuleEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapProductCommandEndpoints();

            return builder;
        }
    }
}
