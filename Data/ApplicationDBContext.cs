using Desafio_BackEnd.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Motorcycle>()
                .HasIndex(m => m.Plate)
                .IsUnique();
        }
    }
}
