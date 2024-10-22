namespace Bibosio.WebApi.Test
{
    public interface ITestService
    {
        string GetItem(string id);
    }

    public class TestService : ITestService
    {
        private readonly ILogger<TestService> _logger;

        public TestService(ILogger<TestService> logger)
        {
            _logger = logger;
        }

        public string GetItem(string id)
        {
            string item = $"MyItem-{id}";

            _logger.LogInformation("Item - {Item}", item);

            return item;
        }
    }
}
