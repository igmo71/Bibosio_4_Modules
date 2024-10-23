using Bibosio.ProductsModule.Domain;
using Bibosio.ProductsModule.Infrastructure.Database.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Bibosio.ProductsModule.Infrastructure.Database
{
    internal class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        { }

        internal DbSet<Category> Categories { get; set; }
        internal DbSet<Option> Options { get; set; }
        internal DbSet<OptionValue> OptionsValues { get; set; }
        internal DbSet<Product> Products { get; set; }
        internal DbSet<ProductOptionValue> ProductOptionValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("product");

            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.ApplyConfiguration(new ProductOptionValueConfiguration());
        }
    }
}
