using Bibosio.CatalogModule.Application;
using Bibosio.CatalogModule.Infrastructure.Database;
using Bibosio.CatalogModule.Interfaces;
using Bibosio.CatalogModule.Presentation;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bibosio.CatalogModule
{
    public static class CatalogConfigExtensions
    {
        public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext/*Pool*/<CatalogDbContext>(options =>
            {
                //options.UseNpgsql(connectionString);
                options.UseSqlite("Data Source=Catalog.db");
            });

            services.AddScoped<CatalogItemCommandService>();
            services.AddScoped<ICatalogItemCommandService, CatalogItemCommandServiceDecorator>();

            services.AddScoped<ICatalogItemQueryService, CatalogItemQueryService>();

            services.AddScoped<ICatalogItemRepository, CatalogItemRepository>();

            return services;
        }

        public static IEndpointRouteBuilder MapCatalogModuleEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapCatalogItemCommandEndpoints();
            builder.MapCatalogItemQueryEndpoints();

            return builder;
        }
    }
}
