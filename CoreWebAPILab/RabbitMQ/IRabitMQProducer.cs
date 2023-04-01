namespace CoreWebAPILab.RabbitMQ
{
    public interface IRabitMQProducer
    {
        public void SendMessage<T>(T message);
    }
}