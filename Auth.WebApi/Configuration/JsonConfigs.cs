using Microsoft.Extensions.DependencyInjection;

namespace Auth.WebApi.Configuration
{
    public static class JsonConfigs
    {
        public static void AddJsonConfiguration(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }
    }
}