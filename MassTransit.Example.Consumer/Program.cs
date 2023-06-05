using MassTransit;
using MassTransit.Example.Consumer.Consumers;

string rabbitMqUri = "amqps://zsnlveev:cUZKbiRaHqFpwyS6n8BifgxqwlebTcqa@toad.rmq.cloudamqp.com/zsnlveev";

string queueName = "example-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory =>
{
    factory.Host(rabbitMqUri);
    factory.ReceiveEndpoint(queueName, endpoint =>
    {
        endpoint.Consumer<ExampleMessageConsumer>();
    });
});

await bus.StartAsync();

Console.Read();  


