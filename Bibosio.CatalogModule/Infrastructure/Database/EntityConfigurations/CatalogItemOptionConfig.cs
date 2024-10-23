using Bibosio.CatalogModule.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bibosio.CatalogModule.Infrastructure.Database.EntityConfigurations
{
    internal class CatalogItemOptionConfig : IEntityTypeConfiguration<CatalogItemOption>
    {
        public void Configure(EntityTypeBuilder<CatalogItemOption> builder)
        {
            builder
                .HasKey(e => new { e.CatalogItemId, e.OptionId, e.OptionValueId });
            builder
                .HasOne(e => e.CatalogItem)
                .WithMany(e => e.CatalogItemOptions)
                .HasForeignKey(e => e.CatalogItemId)
                .HasPrincipalKey(e => e.Id);
            builder
                .HasOne(e => e.Option)
                .WithMany()
                .HasForeignKey(e => e.OptionId)
                .HasPrincipalKey(e => e.Id);
            builder
                .HasOne(e => e.OptionValue)
                .WithMany()
                .HasForeignKey(e => e.OptionValueId)
                .HasPrincipalKey(e => e.Id);
        }
    }
}
