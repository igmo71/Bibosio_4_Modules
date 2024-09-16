using Bibosio.ProductsModule.Domain;
using Bibosio.ProductsModule.Infrastructure.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Bibosio.ProductsModule.Infrastructure.Data
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.HasDefaultSchema("product");

            base.OnModelCreating(modelBuilder);
        }
    }
}
