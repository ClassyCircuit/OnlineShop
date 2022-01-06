using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Tables;

namespace OnlineShop.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Property(t => t.Price)
                .HasPrecision(18, 2);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added && entry.Entity is BaseTable entity)
                {
                    entity.Created = DateTime.UtcNow;
                }
            }

            return base.SaveChanges();
        }
    }
}
