using Bibosio.CatalogModule.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bibosio.CatalogModule.Infrastructure.Database.EntityConfigurations
{
    internal class CatalogItemConfig : IEntityTypeConfiguration<CatalogItem>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .OwnsOne(e => e.Sku);
            builder
                .HasOne(e => e.Parent)
                .WithMany(e => e.Children)
                .HasForeignKey(e => e.ParentId)
                .HasPrincipalKey(e => e.Id);
        }
    }
}
