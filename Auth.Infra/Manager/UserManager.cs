using Auth.Core.Domain;
using Auth.Core.Shared.InputModels.User;
using Auth.Core.Shared.ViewModels.User;
using Auth.Infra.Interface.Manager;
using Auth.Infra.Interface.Repository;
using Auth.Infra.Interface.Services;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth.Infra.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IJwtService jwtService;

        public UserManager(IUserRepository userRepository, IMapper mapper, IJwtService jwtService)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.jwtService = jwtService;
        }

        public Task<UserView> DeleteUserAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> GenerateTokenAsync(AuthUser authUser)
        {
            var user = await userRepository.GetByEmailAndPassword(authUser.Email, authUser.Password);
            if (user == null)
                return null;

            return jwtService.GenerateToken(user);
        }

        public async Task<IEnumerable<UserView>> GetAllUsersAsync()
        {
            return mapper.Map<IEnumerable<UserView>>(await userRepository.GetAllUsersAsync());
        }

        public async Task<UserView> GetUsersByIdAsync(int id)
        {
            return mapper.Map<UserView>(await userRepository.GetUsersByIdAsync(id));
        }

        public async Task<UserView> InsertUserAsync(NewUserInput newUserInput)
        {
            var user = mapper.Map<User>(newUserInput);
            return mapper.Map<UserView>(await userRepository.InsertUserAsync(user));
        }

        public Task<UserView> UpdatetUserAsync(UpdateUserInput updateUserInput)
        {
            throw new System.NotImplementedException();
        }
    }
}