using Bibosio.CatalogModule.Domain;
using Bibosio.CatalogModule.Infrastructure.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Bibosio.CatalogModule.Infrastructure.Data
{
    internal class CatalogDbContext : DbContext
    {
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogItemOption> CatalogItemOptions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<OptionValue> OptionValues { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        { }

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
