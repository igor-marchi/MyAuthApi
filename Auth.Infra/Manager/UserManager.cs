using Auth.Core.Shared.InputModels.User;
using Auth.Core.Shared.ViewModels.User;
using Auth.Infra.Interface.Manager;
using Auth.Infra.Interface.Repository;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth.Infra.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public Task<UserView> DeleteUserAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<UserView>> GetAllUsersAsync()
        {
            return mapper.Map<IEnumerable<UserView>>(await userRepository.GetAllUsersAsync());
        }

        public Task<UserView> GetUsersByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserView> InsertUserAsync(NewUserInput user)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserView> UpdatetUserAsync(UpdateUserInput user)
        {
            throw new System.NotImplementedException();
        }
    }
}