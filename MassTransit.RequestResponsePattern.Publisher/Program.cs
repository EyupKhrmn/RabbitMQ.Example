using MassTransit;
using MassTransit.Example.Shared.RequestResponsePatternMessage;

string rabbitMqUri = "amqps://zsnlveev:cUZKbiRaHqFpwyS6n8BifgxqwlebTcqa@toad.rmq.cloudamqp.com/zsnlveev";

IBusControl bus = Bus.Factory.CreateUsingRabbitMq(factory =>
{
    factory.Host(rabbitMqUri);
});

await bus.StartAsync();

var request = bus.CreateRequestClient<RequestMessage>(new Uri($"{rabbitMqUri}/request-queue"));

int i = 0;
while (true)
{
    await Task.Delay(200);
    var response = await request.GetResponse<ResponseMessage>(new()
    {
        MessageNo = i,
        Text = $"{i}. request"
    });
    
    Console.WriteLine($"Response Received: {response.Message.Text}");
}

Console.Read();