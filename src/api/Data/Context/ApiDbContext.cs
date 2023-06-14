using api.Models.EntityModel.Users;
using Microsoft.EntityFrameworkCore;

namespace api.Data.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options)
            : base(options)
        { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Map();

        }
    }
}