using Desafio_BackEnd.Models;
using Desafio_BackEnd.Models.Utils;
using Microsoft.EntityFrameworkCore;

namespace Desafio_BackEnd.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<Deliveryman> Deliverymen { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Motorcycle>()
                .HasIndex(m => m.Plate)
                .IsUnique();

            modelBuilder.Entity<Deliveryman>(entity =>
            {
                entity.HasIndex(d => d.CNPJ).IsUnique();
                entity.HasIndex(d => d.CNH).IsUnique();
            });
        }
        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Timestamp &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                var entity = (Timestamp)entityEntry.Entity;
                entity.UpdatedAt = DateTime.UtcNow;
                if (entityEntry.State == EntityState.Added)
                    entity.CreatedAt = DateTime.UtcNow;
            }
        }
    }
}
