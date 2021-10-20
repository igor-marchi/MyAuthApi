using Auth.Core.Shared.InputModels.User;
using Auth.Core.Shared.ViewModels.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth.Infra.Interface.Manager
{
    public interface IUserManager
    {
        Task<IEnumerable<UserView>> GetAllUsersAsync();

        Task<UserView> GetUsersByIdAsync(int id);

        Task<UserView> InsertUserAsync(NewUserInput newUserInput);

        Task<UserView> UpdatetUserAsync(UpdateUserInput updateUserInput);

        Task<UserView> DeleteUserAsync(int id);

        Task<string> GenerateTokenAsync(AuthUser authUser);
    }
}