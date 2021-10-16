using Auth.Core.Domain;
using Auth.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Auth.Data.Context
{
    public class AuthContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public AuthContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}