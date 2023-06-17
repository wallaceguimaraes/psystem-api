using api.Models.EntityModel.Addresses;
using api.Models.EntityModel.BusinessTypes;
using api.Models.EntityModel.Cnaes;
using api.Models.EntityModel.Companies;
using api.Models.EntityModel.JuristicPersons;
using api.Models.EntityModel.NaturalPersons;
using api.Models.EntityModel.Persons;
using api.Models.EntityModel.Roles;
using api.Models.EntityModel.Users;
using Microsoft.EntityFrameworkCore;

namespace api.Data.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BusinessType> BusinessTypes { get; set; }
        public DbSet<Cnae> Cnaes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JuristicPerson> JuristicPersons { get; set; }
        public DbSet<NaturalPerson> NaturalPersons { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Map();
            modelBuilder.Entity<Address>().Map();
            modelBuilder.Entity<BusinessType>().Map();
            modelBuilder.Entity<Cnae>().Map();
            modelBuilder.Entity<Company>().Map();
            modelBuilder.Entity<JuristicPerson>().Map();
            modelBuilder.Entity<NaturalPerson>().Map();
            modelBuilder.Entity<Person>().Map();
            modelBuilder.Entity<Role>().Map();

        }
    }
}