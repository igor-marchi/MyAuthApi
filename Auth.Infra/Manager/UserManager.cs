using Auth.Core.Domain;
using Auth.Core.Shared.InputModels.User;
using Auth.Core.Shared.ViewModels.User;
using Auth.Infra.Interface.Manager;
using Auth.Infra.Interface.Repository;
using Auth.Infra.Interface.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
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

        public async Task<AuthenticatedUserView> GenerateTokenAsync(AuthUserInput authUser)
        {
            var searchedUser = mapper.Map<User>(authUser);

            var user = await userRepository.GetByEmailAsync(searchedUser.Email);
            if (user == null)
                return null;

            if (!await VerifyUserCredentialAsync(searchedUser, user.Password))
                return null;

            var authenticatedUser = mapper.Map<AuthenticatedUserView>(user);
            authenticatedUser.Token = jwtService.GenerateToken(user);

            return authenticatedUser;
        }

        private async Task<bool> VerifyUserCredentialAsync(User user, string hash)
        {
            var passwordHasher = new PasswordHasher<User>();
            var status = passwordHasher.VerifyHashedPassword(user, hash, user.Password);

            switch (status)
            {
                case PasswordVerificationResult.Failed:
                    return false;

                case PasswordVerificationResult.Success:
                    return true;

                case PasswordVerificationResult.SuccessRehashNeeded:
                    await UpdatetUserAsync(mapper.Map<UpdateUserInput>(user)); //update hash
                    return true;

                default:
                    throw new InvalidOperationException();
            }
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
            if (await ExistUserEmail(user.Email))
                return null;

            PasswordToHashConverter(user);
            return mapper.Map<UserView>(await userRepository.InsertUserAsync(user));
        }

        private async Task<bool> ExistUserEmail(string userEmail)
        {
            return await userRepository.ExistEmailAsync(userEmail);
        }

        public Task<UserView> UpdatetUserAsync(UpdateUserInput updateUserInput)
        {
            throw new System.NotImplementedException();
        }

        private static void PasswordToHashConverter(User user)
        {
            var passwordHasher = new PasswordHasher<User>();
            user.Password = passwordHasher.HashPassword(user, user.Password);
        }
    }
}