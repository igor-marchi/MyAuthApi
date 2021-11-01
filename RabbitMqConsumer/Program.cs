using Auth.Core.Shared.RabbitMq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Net.Mail;
using System.Text;
using System.Text.Json;

namespace RabbitMqConsumer
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Iniciando Worker de envio de email...");
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            {
                channel.QueueDeclare(queue: "User.Created",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                Console.WriteLine("Esperando menssagens");

                while (true)
                {
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        try
                        {
                            var body = ea.Body.ToArray();
                            var message = Encoding.UTF8.GetString(body);
                            var emailData = JsonSerializer.Deserialize<EmailData>(message);
                            SendEmail(emailData);
                            Console.WriteLine("Email enviado");
                            channel.BasicAck(ea.DeliveryTag, false);
                        }
                        catch (Exception err)
                        {
                            Console.WriteLine($"Error: {err.Message}");
                            channel.BasicNack(ea.DeliveryTag, false, true);
                        }
                    };

                    channel.BasicConsume(queue: "User.Created", autoAck: false, consumer: consumer);
                }
            }
        }

        private static void SendEmail(EmailData emailData)
        {
            SmtpClient client = new()
            {
                Host = "smtp.gmail.com",
                Port = Convert.ToInt32("587"),
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("testesmtp123456789@gmail.com", "VrauVrau123"),
            };

            MailMessage mail = new()
            {
                From = new MailAddress("testesmtp123456789@gmail.com", "Zé Povinho"),
                Body = emailData.Content,
                Subject = "Usuário criado com sucesso",
                Priority = MailPriority.High
                //IsBodyHtml = true,
            };

            mail.To.Add(new MailAddress(emailData.EmailAddress, "Você"));
            client.Send(mail);
        }
    }

}
