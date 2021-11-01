using Auth.Infra.Validator.InputModels.Role;
using Auth.Infra.Validator.InputModels.User;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Auth.WebApi.Configuration
{
    public static class FluentValidationAndJsonConfigs
    {
        public static void AddFluentValidationAndJsonConfiguration(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddJsonOptions(x => x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())) // caso venha a usar enums
                .AddFluentValidation(configs =>
                 {
                     // user
                     configs.RegisterValidatorsFromAssemblyContaining<BaseUserInputValidator>();
                     configs.RegisterValidatorsFromAssemblyContaining<NewUserInputValidator>();
                     configs.RegisterValidatorsFromAssemblyContaining<UpdateUserInputValidator>();
                     configs.RegisterValidatorsFromAssemblyContaining<AuthUserInputValidator>();

                     // role
                     configs.RegisterValidatorsFromAssemblyContaining<BaseRoleInputValidator>();
                     configs.RegisterValidatorsFromAssemblyContaining<NewRoleInputValidator>();
                     configs.RegisterValidatorsFromAssemblyContaining<UpdateRoleInputValidator>();
                     configs.RegisterValidatorsFromAssemblyContaining<RoleReferenceInputValidator>();

                     configs.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
                 });
        }
    }
}