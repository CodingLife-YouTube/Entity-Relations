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
            // Fluent API method
            base.OnModelCreating(modelBuilder);

            var user = modelBuilder.Entity<User>();
            user.HasKey(x => x.Id); //PK
            user.Property(p=>p.FirstName).IsRequired();
           




            var address = modelBuilder.Entity<UserAddress>();
            address.HasKey(x => x.Id);//pk

            address.HasOne(x => x.User)  //fk
                    .WithOne(x => x.Address)
                    .HasForeignKey<UserAddress>(fk=>fk.UserId);
           

            





        }
    }
}
