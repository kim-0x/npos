using Microsoft.EntityFrameworkCore;
using NPos.Infrastructure.Entity;

namespace NPos.Infrastructure.Persistence
{
    public class NPosContext(DbContextOptions<NPosContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StockItem> StockItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Cost)
                    .HasPrecision(18, 2);
            });
        }
    }
}
