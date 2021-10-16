using Auth.Infra.Mapping.RoleMapping;
using Auth.Infra.Mapping.UserMapping;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.WebApi.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(UserMappingProfile),
                typeof(RoleMappingProfile));
        }
    }
}