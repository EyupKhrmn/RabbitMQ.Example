using MassTransit;
using MassTransit.Example.Shared.MessageTypes;

string rabbitMqUri = "amqps://zsnlveev:cUZKbiRaHqFpwyS6n8BifgxqwlebTcqa@toad.rmq.cloudamqp.com/zsnlveev";

string queueName = "example-queue";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory =>
{
    factory.Host(rabbitMqUri);
});


ISendEndpoint sendEndpoint = await bus.GetSendEndpoint(new($"{rabbitMqUri}/{queueName}"));

Console.Write("Gönderilecek Mesaj: ");
string message = Console.ReadLine();
await sendEndpoint.Send<IMessage>(new ExampleMessage()
{
    Text = message
});

Console.Read();