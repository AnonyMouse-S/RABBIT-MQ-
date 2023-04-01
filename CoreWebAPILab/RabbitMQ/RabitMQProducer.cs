using Microsoft.AspNetCore.Connections;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace CoreWebAPILab.RabbitMQ
{
    public class RabitMQProducer : IRabitMQProducer
    {
        const string queueName = "reservation";

        public void SendMessage<T>(T message)
        {
            //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            //Create the RabbitMQ connection using connection factory details as mentioned above
            using (var rabbitConnection = factory.CreateConnection())
            {
                //Here we create channel with session and model
                using (var channel = rabbitConnection.CreateModel())
                {
                    //declare the queue after mentioning name and a few property related to that
                    channel.QueueDeclare(queueName, exclusive: false, autoDelete: false);

                    //Serialize the message
                    var json = JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(json);

                    //put the data on to the product queue
                    channel.BasicPublish(exchange: "", routingKey: queueName, body: body);
                }
            }
        }
    }
}