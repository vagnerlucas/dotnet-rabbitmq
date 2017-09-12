using System;
using System.Collections.Generic;
using RabbitMQ.Client;

namespace MailReceiver.Config 
{
    class RabbitConfig {

        public const string RABBITMQ_CFG_DEFAULT_QUEUE = "mail";
        public const bool RABBITMQ_CFG_DURABLE = false;
        public const bool RABBITMQ_CFG_EXCLUSIVE = false;
        public const bool RABBITMQ_CFG_AUTO_DELETE = false;
        public const Dictionary<string, object> RABBITMQ_CFG_ARGS = null;
        internal const bool RABBITMQ_CFG_AUTOACK = true;

        public static ConnectionFactory GetConnectionFactory()
        {
            const string RABBITMQ_USER_NAME = "mail";
            const string RABBITMQ_USER_PASSWD = "mail@123";
            const string RABBITMQ_VHOST = "/";
            const string RABBITMQ_HOSTNAME = "172.20.0.17";
            const int RABBITMQ_PORT = 5672;


            return new ConnectionFactory()
            {
                UserName = RABBITMQ_USER_NAME,
                Password = RABBITMQ_USER_PASSWD,
                VirtualHost = RABBITMQ_VHOST,
                HostName = RABBITMQ_HOSTNAME,
                Port = RABBITMQ_PORT
            };

        }

    }

}