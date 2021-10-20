using Auth.Core.Domain;

namespace Auth.Infra.Interface.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}