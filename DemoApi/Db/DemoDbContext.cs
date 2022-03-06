using DemoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.Db
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



        }
    }
}
