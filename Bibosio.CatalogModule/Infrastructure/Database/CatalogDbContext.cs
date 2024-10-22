using Bibosio.CatalogModule.Domain;
using Bibosio.CatalogModule.Infrastructure.Database.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Bibosio.CatalogModule.Infrastructure.Database
{
    internal class CatalogDbContext(DbContextOptions<CatalogDbContext> options) : DbContext(options)
    {
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogItemOption> CatalogItemOptions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<OptionValue> OptionValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("catalog");

            modelBuilder.ApplyConfiguration(new CatalogItemConfig());

            modelBuilder.ApplyConfiguration(new CatalogItemOptionConfig());

            modelBuilder.ApplyConfiguration(new OptionConfig());

            modelBuilder.ApplyConfiguration(new OptionValueConfig());
        }

    }
}
