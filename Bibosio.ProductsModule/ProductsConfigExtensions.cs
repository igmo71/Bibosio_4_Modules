using Bibosio.Interfaces;
using Bibosio.ProductsModule.Application;
using Bibosio.ProductsModule.Endpoints;
using Bibosio.ProductsModule.Infrastructure.Data;
using Bibosio.ProductsModule.Infrastructure.EventBus.Events;
using Bibosio.ProductsModule.Infrastructure.EventBus.Kafka;
using Bibosio.ProductsModule.Interfaces;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bibosio.ProductsModule
{
    public static class ProductsConfigExtensions
    {
        public static IServiceCollection AddProductsModule(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext/*Pool*/<ProductsDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCommandService, ProductCommandService>();
            services.AddScoped<IProductQueryService, ProductQueryService>();

            services.AddSingleton<IEventBusProducer<ProductCreatedEvent>, KafkaProductCreatedProducer>();
            //services.AddSingleton<IEventBusProducer<ProductUpdatedEvent>, KafkaProductUpdatedProducer>(); // TODO: NotImplemented


            services.AddHostedService<KafkaProductCreatedConsumer>();
            //services.AddHostedService<KafkaProductUpdatedConsumer>(); // TODO: NotImplemented

            return services;
        }

        public static IEndpointRouteBuilder MapProductModuleEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapProductCommandEndpoints();
            builder.MapProductQueryEndpoints();

            return builder;
        }
    }
}
