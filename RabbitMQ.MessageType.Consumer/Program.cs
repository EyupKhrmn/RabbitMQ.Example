using System.Runtime.Loader;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

#region Connection

//bağlantı oluşturma
ConnectionFactory factory = new ();
factory.Uri = new ("amqps://zsnlveev:cUZKbiRaHqFpwyS6n8BifgxqwlebTcqa@toad.rmq.cloudamqp.com/zsnlveev");

//Bağlantı aktifleştirme ve kanal açma
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

#endregion

#region P2P (Ponint-To-Point) Type

// string queueName = "example-p2p";
//
// channel.QueueDeclare(
//     queueName,
//     durable: false,
//     exclusive: false,
//     autoDelete: false);
//
// EventingBasicConsumer consumer = new(channel);
//
// channel.BasicConsume(
//     queue: queueName,
//     autoAck: false,
//     exclusive: false,
//     consumer: consumer);
//
// consumer.Received += (sender, e) =>
// {
//     string message = Encoding.UTF8.GetString(e.Body.Span);
//     Console.WriteLine(message);
// };

#endregion

#region Publish / Subscribe (Puv/Sub) Type

// string exchangeName = "example-pub/sub";
//
// channel.ExchangeDeclare(
//     exchange: exchangeName,
//     type: ExchangeType.Fanout);
//
// string queueName = "example-pub/sub";
//
// channel.QueueBind(
//     queue: queueName,
//     exchange: exchangeName,
//     routingKey: string.Empty);
//
// EventingBasicConsumer consumer = new(channel);
//
// channel.BasicConsume(
//     queue: queueName,
//     autoAck: false,
//     consumer: consumer);
//
// consumer.Received += (sender, e) =>
// {
//     Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));
// };

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
// EventingBasicConsumer consumer = new(channel);
//
// channel.BasicConsume(
//     queue: queueName,
//     autoAck: true,
//     consumer: consumer);
//
// channel.BasicQos(
//     prefetchCount: 1,
//     prefetchSize: 0,
//     global: false);
//
// consumer.Received += (sender, e) =>
// {
//     Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));
// };

#endregion

#region Request/Response Type

// string queueName = "example-request-response";
//
// channel.QueueDeclare(
//     queue: queueName,
//     durable: false,
//     exclusive: false,
//     autoDelete: false);
//
// EventingBasicConsumer consumer = new(channel);
//
// channel.BasicConsume(
//     queue: queueName,
//     autoAck: false,
//     consumer: consumer);
//
// consumer.Received += (sender, e) =>
// {
//     Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));
//
//     byte[] responseMessage = Encoding.UTF8.GetBytes("İşlem Tamamlandı");
//
//     IBasicProperties properties = e.BasicProperties;
//     IBasicProperties replyProperties = channel.CreateBasicProperties();
//     replyProperties.CorrelationId = properties.CorrelationId;
//     channel.BasicPublish(
//         exchange: string.Empty,
//         routingKey: properties.ReplyTo,
//         basicProperties: replyProperties,
//         body: responseMessage);
// };

#endregion

Console.Read();