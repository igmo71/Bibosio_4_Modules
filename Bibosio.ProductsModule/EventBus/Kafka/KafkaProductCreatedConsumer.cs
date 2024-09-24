using Bibosio.ProductsModule.EventBus.Events;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Bibosio.ProductsModule.EventBus.Kafka
{
    internal class KafkaProductCreatedConsumer : BackgroundService
    {
        private readonly string _topic;
        private readonly IConsumer<string, ProductCreatedEvent> _consumer;
        private readonly ILogger<KafkaProductCreatedConsumer> _logger;

        public KafkaProductCreatedConsumer(IConfiguration configuration, ILogger<KafkaProductCreatedConsumer> logger)
        {
            _topic = configuration["Kafka:ProductCreatedTopic"]
                ?? throw new ApplicationException("Kafka ProductCreatedTopic not found");

            var config = new ConsumerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"],
                GroupId = "product-created-group",
                //AutoOffsetReset = AutoOffsetReset.Earliest, // Начать с самого раннего доступного оффсета
                //EnableAutoCommit = true // Автоматическая фиксация оффсетов
            };

            _consumer = new ConsumerBuilder<string, ProductCreatedEvent>(config)
                .SetValueDeserializer(new KafkaDeserializer<ProductCreatedEvent>())
                .Build();

            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug("ConsumeMessage - Start");

            _consumer.Subscribe(_topic);

            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var consumeResult = _consumer.Consume(1000);

                    if (consumeResult != null)
                    {
                        _logger.LogDebug("ConsumeMessage {@MessageValue}", consumeResult.Message.Value);
                    }

                    await Task.Delay(2000, stoppingToken);
                }
            }
            catch (ConsumeException ex)
            {
                _logger.LogError(ex, "ConsumeMessage - ConsumeException {Message}", ex.Message);
            }
            catch(OperationCanceledException ex)
            {
                _logger.LogError(ex, "ConsumeMessage - OperationCanceledException {Message}", ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ConsumeMessage - Exception {Message}", ex.Message);
                //throw;
            }
            finally
            {
                _consumer.Close();
            }
        }

        public override void Dispose()
        {
            _consumer.Dispose();
            base.Dispose();
        }
    }
}
