using System.Diagnostics.Contracts;
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

#region BasicExample

// //Queue oluşturma
// channel.QueueDeclare(queue:"example-queue", exclusive:false);
//
// //Queue'ya mesaj gönderme
// //Rabbitmq kuyruğa atacağı mesajları byte tipinde kabul etmektedir. BU yüzden meajları byte türünde atmamız gerekir.
// // byte[] message = Encoding.UTF8.GetBytes("Merhaba");
// // channel.BasicPublish(exchange:"",routingKey:"example-queue", body:message);
//
// for (int i = 0; i < 100; i++)
// { 
//     await Task.Delay(200);
//     byte[] message = Encoding.UTF8.GetBytes("Merhaba " + i);
//     channel.BasicPublish(exchange:"",routingKey:"example-queue", body:message);
// }

#endregion

#region DirectExchangeExample

// channel.ExchangeDeclare(exchange:"direct-exchange",type: ExchangeType.Direct);
//
//
// while (true)
// {
//     Console.Write("Mesaj: ");
//     string message = Console.ReadLine();
//     byte[] byteMessage = Encoding.UTF8.GetBytes(message);
//
//     channel.BasicPublish(
//         exchange:"direct-exchange", 
//         routingKey:"direct-queue", 
//         body: byteMessage);
// }
#endregion

#region FanoutExchangeExample

// channel.ExchangeDeclare(exchange:"fanout-exchange",type: ExchangeType.Fanout);
//
// for (int i = 0; i < 101; i++)
// {
//     await Task.Delay(200);
//     byte[] message = Encoding.UTF8.GetBytes("Merhaba " + i);
//     channel.BasicPublish(
//         exchange: "fanout-exchange",
//         routingKey: "",
//         body: message);
// }

#endregion

#region TopicExchangeExample

// channel.ExchangeDeclare(exchange: "topic-exchange",type: ExchangeType.Topic);
//
// for (int i = 0; i < 101; i++)
// {
//     await Task.Delay(200);
//     byte[] message = Encoding.UTF8.GetBytes("Merhaba " + i);
//     Console.Write("Topic belirtiniz: ");
//     string topic = Console.ReadLine();
//     channel.BasicPublish(exchange: "topic-exchange",routingKey: topic, body: message);
// }

#endregion

#region HeaderExchangeExample

channel.ExchangeDeclare(exchange: "header-exchange",ExchangeType.Headers);

for (int i = 0; i < 101; i++)
{
    await Task.Delay(200);
    byte[] message = Encoding.UTF8.GetBytes("Merhaba " + i);
    Console.WriteLine("Mesajın yollancağı headeri giriniz: ");
    string headers = Console.ReadLine();

   IBasicProperties properties = channel.CreateBasicProperties();
   properties.Headers = new Dictionary<string, object>()
   {
       ["no"] = headers
   };
    
    channel.BasicPublish(
        exchange: "header-exchange",
        routingKey:"",body:message,
        basicProperties: properties);
    
}

#endregion

Console.Read();