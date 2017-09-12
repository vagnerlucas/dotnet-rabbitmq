using System;
using MailReceiver.Config;
using MailReceiver.Models;
using MessagePack;
using RabbitMQ.Client.Events;

namespace MailReceiver 
{
    class Consumer 
    {
        public void Start()
        {
            var factory = RabbitConfig.GetConnectionFactory();

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: RabbitConfig.RABBITMQ_CFG_DEFAULT_QUEUE, durable: RabbitConfig.RABBITMQ_CFG_DURABLE, exclusive: RabbitConfig.RABBITMQ_CFG_EXCLUSIVE, 
                                         autoDelete: RabbitConfig.RABBITMQ_CFG_AUTO_DELETE, arguments: RabbitConfig.RABBITMQ_CFG_ARGS);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += ConsumerReceived;

                    channel.BasicConsume(queue: RabbitConfig.RABBITMQ_CFG_DEFAULT_QUEUE, autoAck: RabbitConfig.RABBITMQ_CFG_AUTOACK, consumer: consumer, consumerTag: "", 
                                         noLocal: true, exclusive: false, arguments: null);
                }
            }
        }

        private void ConsumerReceived(object model, BasicDeliverEventArgs ea) 
        {
            try
            {
                var body = ea.Body;

                var message = MessagePackSerializer.Deserialize<EmailMessageModel>(body);
                new MailSender(message.EmailConfig).Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}