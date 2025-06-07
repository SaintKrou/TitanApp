using Microsoft.EntityFrameworkCore;
using TitanApp.Models;

namespace TitanApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=titanapp.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(c => c.Id);
            modelBuilder.Entity<Client>().Property(c => c.LastName).IsRequired();
            modelBuilder.Entity<Client>().Property(c => c.FirstName).IsRequired();
            modelBuilder.Entity<Client>().Property(c => c.Unlimited).HasDefaultValue(false);

            modelBuilder.Entity<Purchase>().HasKey(p => p.Id);
            modelBuilder.Entity<Purchase>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Purchase>().Property(p => p.SessionsCount).IsRequired();
            modelBuilder.Entity<Purchase>().Property(p => p.Unlimited).IsRequired();
            modelBuilder.Entity<Purchase>().Property(p => p.DurationMonths).IsRequired();
        }
    }
}
