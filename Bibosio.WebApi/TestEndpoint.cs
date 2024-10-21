namespace Bibosio.WebApi
{
    public static class TestEndpoint
    {
        public static IEndpointRouteBuilder MapTestEndpoint(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/test/{id}", (string id, ITestService testService) =>
            {
                var result = testService.GetItem(id);

                return result;
            });

            return builder;
        }
    }
}
