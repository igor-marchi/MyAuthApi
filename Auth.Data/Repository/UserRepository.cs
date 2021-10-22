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

        public async Task<User> GetByEmailAsync(string email)
        {
            return await context.Users
                .Include(u => u.Roles)
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> ExistEmailAsync(string email)
        {
            return await context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<User> GetUsersByIdAsync(int id)
        {
            return await context.Users
                .Include(u => u.Roles)
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> InsertUserAsync(User user)
        {
            await InsertUserRoleAsync(user);

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        private async Task InsertUserRoleAsync(User user)
        {
            var roleList = new List<Role>();

            foreach (var role in user.Roles)
            {
                roleList.Add(await context.Roles.FindAsync(role.Id));
            }
            user.Roles = roleList;
        }

        public async Task<User> UpdatetUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}