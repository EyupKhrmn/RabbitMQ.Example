using MassTransit.Example.Shared.MessageTypes;

namespace MassTransit.Example.WorkerService.Publisher.Services;

public class PublisMessageServices : BackgroundService
{
    private readonly IPublishEndpoint _publishEndpoint;

    public PublisMessageServices(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        int i = 0;
        while (true)
        {
            ExampleMessage message = new()
            {
                Text = $"{++i}. Mesaj"
            };
            await _publishEndpoint.Publish(message);
        }
    }
}