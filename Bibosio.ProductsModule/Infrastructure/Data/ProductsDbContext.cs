using Bibosio.ProductsModule.Domain;
using Bibosio.ProductsModule.Infrastructure.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Bibosio.ProductsModule.Infrastructure.Data
{
    internal class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        { }

        internal DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("product");

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
