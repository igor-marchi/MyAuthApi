using Auth.Core.Shared.RabbitMq;
using Auth.Infra.Interface.Services;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;

namespace Auth.Data.Service.RabbitMq
{
    public class PublishService : IPublishService
    {
        public PublishService()
        {}

        public bool PublishEmailService(EmailData email)
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();
                channel.QueueDeclare(queue: "User.Created",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonSerializer.Serialize(email);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                             routingKey: "User.Created",
                                            basicProperties: null,
                                            body: body);

                Console.WriteLine($"Published message for email: {email.EmailAddress}");
                return true;
            }
            catch (Exception err)
            {
                Console.WriteLine($"Error: {err.Message}");
                return false;
            }
        }
    }
}
