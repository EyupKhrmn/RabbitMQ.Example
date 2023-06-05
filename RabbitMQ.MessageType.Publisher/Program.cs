using System.Globalization;
using System.Text;
using RabbitMQ.Client;

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

string exchangeName = "example-pub/sub";

channel.ExchangeDeclare(
    exchange: exchangeName,
    type: ExchangeType.Fanout);

for (int i = 0; i < 101; i++)
{
    byte[] body = Encoding.UTF8.GetBytes("Merhaba " + i);

    channel.BasicPublish(
        exchange: exchangeName,
        routingKey: string.Empty,
        body: body);
}

#endregion


Console.Read();