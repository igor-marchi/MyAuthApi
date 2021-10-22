using Auth.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth.Infra.Interface.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<User> GetUsersByIdAsync(int id);

        Task<User> InsertUserAsync(User user);

        Task<User> UpdatetUserAsync(User user);

        Task<User> DeleteUserAsync(int id);

        Task<User> GetByEmailAsync(string email);
    }
}