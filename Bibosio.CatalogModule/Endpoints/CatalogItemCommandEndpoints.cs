using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibosio.CatalogModule.Endpoints
{
    public static class CatalogItemCommandEndpoints
    {
        public static IEndpointRouteBuilder MapCatalogItemCommandEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/api/catalog")
                .WithTags("Catalog");

            group.MapPost("/", CatalogItemCommandHandler.CreateCatalogItemAsync)
                .WithName("CreateCatalogItem");

            group.MapPut("/", CatalogItemCommandHandler.UpdateCatalogItemAsync)
                .WithName("UpdateCatalogItem");

            group.MapDelete("/{id}", CatalogItemCommandHandler.DeleteCatalogItemAsync)
                .WithName("DeleteCatalogItem");
            return builder;
        }
    }
}
