using MassTransit;
using MassTransit.Example.WorkerService.Publisher;
using MassTransit.Example.WorkerService.Publisher.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddMassTransit(configurator =>
        {
            configurator.UsingRabbitMq((context, _configurator) =>
            {
                _configurator.Host("amqps://zsnlveev:cUZKbiRaHqFpwyS6n8BifgxqwlebTcqa@toad.rmq.cloudamqp.com/zsnlveev");
            });
        });

        services.AddHostedService<PublisMessageServices>(provider =>
        {
            using IServiceScope scope = provider.CreateScope();
            IPublishEndpoint publishEndpoint = scope.ServiceProvider.GetService<IPublishEndpoint>();
            return new(publishEndpoint);
        });
    })
    .Build();



await host.RunAsync();