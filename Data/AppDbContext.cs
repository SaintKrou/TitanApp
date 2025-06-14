using Microsoft.EntityFrameworkCore;
using TitanApp.Models;

namespace TitanApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        // DbSet для логов подписок
        public DbSet<SubscriptionLogs> SubscriptionLogs { get; set; }

        // Удобный псевдоним
        public DbSet<SubscriptionLogs> Logs => SubscriptionLogs;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=titanapp.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.LastName).IsRequired();
                entity.Property(c => c.FirstName).IsRequired();
                entity.Property(c => c.Unlimited).HasDefaultValue(false);
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired();
                entity.Property(p => p.SessionsCount).IsRequired();
                entity.Property(p => p.Unlimited).IsRequired();
                entity.Property(p => p.DurationMonths).IsRequired();
                entity.Property(p => p.Cost).IsRequired();
            });

            modelBuilder.Entity<SubscriptionLogs>(entity =>
            {
                entity.ToTable("SubscriptionLogs"); // Явное имя таблицы

                entity.HasKey(s => s.Id);
                entity.Property(s => s.ClientId).IsRequired();
                entity.Property(s => s.ClientName).IsRequired();
                entity.Property(s => s.PurchaseName).IsRequired();
                entity.Property(s => s.Cost).IsRequired();
                entity.Property(s => s.PaymentMethod).IsRequired();
                entity.Property(s => s.AppliedAt).IsRequired();
                entity.Property(s => s.NewSubscriptionEnd).IsRequired();
                entity.Property(s => s.Unlimited).IsRequired();

                entity.HasOne<Client>()
                      .WithMany()
                      .HasForeignKey(s => s.ClientId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
