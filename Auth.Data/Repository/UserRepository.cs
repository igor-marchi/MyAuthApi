using Auth.Core.Domain;
using Auth.Data.Context;
using Auth.Infra.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthContext context;

        public UserRepository(AuthContext context)
        {
            this.context = context;
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await context.Users
                .Include(u => u.Roles)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User> GetUsersByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> InsertUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> UpdatetUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}