using System.Globalization;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

#region Connection

//Bağlantı Oluşturma işlemi
ConnectionFactory factory = new();
factory.Uri = new ("amqps://zsnlveev:cUZKbiRaHqFpwyS6n8BifgxqwlebTcqa@toad.rmq.cloudamqp.com/zsnlveev");


//Bağlantıyı aktifleştirme ve kanal açma
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

#endregion

#region P2P (Ponint-To-Point) Type

//string queueName = "eample-p2p";

// channel.QueueDeclare(
//     queueName,
//     durable: false,
//     exclusive: false,
//     autoDelete: false);
//
// byte[] message = Encoding.UTF8.GetBytes("Merhaba");
//
// channel.BasicPublish(
//     exchange: string.Empty,
//     routingKey: queueName,
//     body: message);

#endregion

#region Publish / Subscribe (Puv/Sub) Type

// string exchangeName = "example-pub/sub";
//
// channel.ExchangeDeclare(
//     exchange: exchangeName,
//     type: ExchangeType.Fanout);
//
// for (int i = 0; i < 101; i++)
// {
//     byte[] body = Encoding.UTF8.GetBytes("Merhaba " + i);
//
//     channel.BasicPublish(
//         exchange: exchangeName,
//         routingKey: string.Empty,
//         body: body);
// }

#endregion

#region Work Queue Type

// string queueName = "example-work";
//
// channel.QueueDeclare(
//     queue: queueName,
//     durable: false,
//     exclusive: false,
//     autoDelete: false);
//
// IBasicProperties properties = channel.CreateBasicProperties();
// properties.Persistent = true;
//
// for (int i = 0; i < 101; i++)
// {
//     byte[] body = Encoding.UTF8.GetBytes("Merhaba");
//
//     channel.BasicPublish(
//         exchange: string.Empty,
//         routingKey: queueName,
//         body: body,
//         basicProperties: properties);
// }

#endregion

#region Request/Response Type

string queueName = "example-request-response";

#region Publisher işlemleri

channel.QueueDeclare(
    queue: queueName,
    durable: false,
    exclusive: false,
    autoDelete: false);

string replyQueueName = channel.QueueDeclare().QueueName;

string correlationId = Guid.NewGuid().ToString();

IBasicProperties properties = channel.CreateBasicProperties();
properties.CorrelationId = correlationId;

properties.ReplyTo = replyQueueName;

byte[] body = Encoding.UTF8.GetBytes("Request Message");

channel.BasicPublish(
    exchange: string.Empty,
    routingKey: queueName,
    body: body,
    basicProperties: properties);


#endregion

#region Consumer İşlemleri

EventingBasicConsumer consumer = new(channel);

channel.BasicConsume(
    queue: queueName,
    autoAck: false,
    consumer: consumer);

consumer.Received += (sender, e) =>
{
    if (e.BasicProperties.CorrelationId == correlationId)
    {
        Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));
    }
};

#endregion

#endregion


Console.Read();