using Auth.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Auth.Data.Context
{
    public class AuthContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public AuthContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }
    }
}