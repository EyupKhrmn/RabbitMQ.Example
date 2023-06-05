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

#region BasicExample

// //Queue oluşturma
// channel.QueueDeclare(queue: "example-queue", exclusive: false);//consumer dea da kuyruk publisher daki ile birebir aynı yapılandırma ile tanımlanmalıdır.
//
//
// //Queue'dan mesaj okuma
// EventingBasicConsumer consumer = new (channel);
// channel.BasicConsume( consumer,"example-queue", autoAck:false);
// consumer.Received += (sender, e) =>
// {
//     //kuyruğa gelen mesajın işlendiği alandır.
//     //e.body: Kuyrukratki mesahın verisini bütünsel olarak getirecektir.
//     //e.body.Span veya e.body.TaArray() : Kuyruktaki verinin byte verisini getirecektir.
//     Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));
//     channel.BasicAck(e.DeliveryTag,multiple:false);
// };

#endregion

#region DirectExchangeExample

// channel.ExchangeDeclare(exchange:"direct-exchange",type: ExchangeType.Direct);
//
// string queueName = channel.QueueDeclare().QueueName;
//
//
// channel.QueueBind(queue: queueName, exchange: "direct-exchange", routingKey: "direct-queue");
//
// EventingBasicConsumer consumer = new(channel);
// channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
//
// consumer.Received += (sender, e) =>
// {
//     string message = Encoding.UTF8.GetString(e.Body.Span);
//     Console.WriteLine(message);
// };
#endregion

#region FanoutExchangeExample

// channel.ExchangeDeclare(exchange:"fanout-exchange", type: ExchangeType.Fanout);
//
// Console.Write("Kuyruk Adını Giriniz: ");
// string queueName = Console.ReadLine();
// channel.QueueDeclare(queue: queueName, exclusive: false);
//
// channel.QueueBind(queue: queueName,exchange: "fanout-exchange",routingKey:"");
//
// EventingBasicConsumer consumer = new(channel);
// channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
// consumer.Received += (sender, e) =>
// {
//     string message = Encoding.UTF8.GetString(e.Body.Span);
//     Console.WriteLine(message);
// };

#endregion

#region TopicExchangeExample

// channel.ExchangeDeclare(exchange: "topic-exchange",ExchangeType.Topic);
//
// Console.Write("Dinlenecek Topic formatını belirtiniz: ");
// string topic = Console.ReadLine();
//
// string queueName = channel.QueueDeclare().QueueName;
//
// channel.QueueBind(queueName,exchange: "topic-exchange",routingKey: topic);
//
// EventingBasicConsumer consumer = new(channel);
// channel.BasicConsume(queueName, autoAck: true, consumer);
//
// consumer.Received += (sender, e) =>
// {
//     string message = Encoding.UTF8.GetString(e.Body.Span);
//     Console.WriteLine(message);
// };
#endregion

#region HeaderExchangeExample

// channel.ExchangeDeclare(exchange: "header-exchange",ExchangeType.Headers);
// Console.WriteLine("Lütfen Header Value'sunu giriniz: ");
// string value = Console.ReadLine();
//
// string queueName = channel.QueueDeclare().QueueName;
//
// channel.QueueBind(
//     queueName,exchange:"header-exchange",
//     routingKey:string.Empty,
//     new Dictionary<string, object>
//     {
//         ["x-match"] = "any",//default olarak any gelir istenirle all da yapılabilir. any halinde iken header'da herhangi bir değer tutarsa mesajı yollar
//                             // all halinde ise tüm header'ların birbirini tutması gerekir. 
//         ["no"] = value
//     });
//
//
// EventingBasicConsumer consumer = new(channel);
//
// channel.BasicConsume(
//     queueName,
//     autoAck: true,
//     consumer: consumer);
//
// consumer.Received += (sender, e) =>
// {
//     string message = Encoding.UTF8.GetString(e.Body.Span);
//     Console.WriteLine(message);
// };

#endregion

Console.ReadLine();