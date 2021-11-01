using Auth.Data.Repository;
using Auth.Data.Service.RabbitMq;
using Auth.Infra.Interface.Manager;
using Auth.Infra.Interface.Repository;
using Auth.Infra.Interface.Services;
using Auth.Infra.Manager;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.WebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddRepositoryDependencyInjectionConfiguration(this IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddManagerDependencyInjectionConfiguration(this IServiceCollection service)
        {
            service.AddScoped<IUserManager, UserManager>();
        }

        public static void AddServiceDependencyInjectionConfiguration(this IServiceCollection service)
        {
            service.AddScoped<IPublishService, PublishService>();
        }
    }
}