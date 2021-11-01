using Auth.Core.Shared.RabbitMq;

namespace Auth.Infra.Interface.Services
{
    public interface IPublishService
    {
        bool PublishEmailService(EmailData email);
    }
}
