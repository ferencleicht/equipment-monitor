using System.Net;
using System.Text.Json;
using Amazon.SQS;
using Amazon.SQS.Model;
using Api.Interfaces;
using Api.Messages;

namespace Api.Services;

public class QueueConsumer : BackgroundService
{
    private readonly IAmazonSQS _sqsClient;
    private const string QueueName = "equipment.fifo";
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<QueueConsumer> _logger;

    public QueueConsumer(IAmazonSQS sqsClient, ILogger<QueueConsumer> logger, IServiceScopeFactory serviceScopeFactory)
    {
        _sqsClient = sqsClient;
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var queueUrl = await _sqsClient.GetQueueUrlAsync(QueueName, stoppingToken);

        var receiveRequest = new ReceiveMessageRequest
        {
            QueueUrl = queueUrl.QueueUrl,
            MessageAttributeNames = new List<string> { "All" },
        };

        while (!stoppingToken.IsCancellationRequested)
        {
            var messageResponse = await _sqsClient.ReceiveMessageAsync(receiveRequest, stoppingToken);

            if(messageResponse.HttpStatusCode != HttpStatusCode.OK)
            {
                _logger.LogError("Failed to receive message from queue {QueueName}", QueueName);
                continue;
            }

            foreach (var message in messageResponse.Messages)
            {
                var messageBody = JsonSerializer.Deserialize<EquipmentStateChanged>(message.Body);
                
                if (messageBody == null)
                {
                    _logger.LogError("Failed to deserialize message body {MessageBody}", message.Body);
                    continue;
                }
                
                using var scope = _serviceScopeFactory.CreateScope();
                var handler = scope.ServiceProvider.GetRequiredService<IMessageHandler<EquipmentStateChanged>>();
                await handler.HandleAsync(messageBody);
                await _sqsClient.DeleteMessageAsync(queueUrl.QueueUrl, message.ReceiptHandle, stoppingToken);
            }
        }
    }
}
