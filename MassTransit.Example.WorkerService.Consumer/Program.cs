using MassTransit;
using MassTransit.Configuration;
using MassTransit.Example.WorkerService.Consumer;
using MassTransit.Example.WorkerService.Consumer.Consumers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddMassTransit(configurator =>
        {
            configurator.AddConsumer<ExampleMessageConsumer>();
            configurator.UsingRabbitMq((context, _configurator) =>
            {
                _configurator.Host("amqps://zsnlveev:cUZKbiRaHqFpwyS6n8BifgxqwlebTcqa@toad.rmq.cloudamqp.com/zsnlveev");
                _configurator.ReceiveEndpoint("example-message-queue",e => e.ConfigureConsumer<ExampleMessageConsumer>(context));
            });
        });
    })
    .Build();

await host.RunAsync();