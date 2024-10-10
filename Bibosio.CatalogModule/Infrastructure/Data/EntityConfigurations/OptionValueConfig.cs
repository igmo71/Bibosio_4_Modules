using Bibosio.CatalogModule.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bibosio.CatalogModule.Infrastructure.Data.EntityConfigurations
{
    internal class OptionValueConfig : IEntityTypeConfiguration<OptionValue>
    {
        public void Configure(EntityTypeBuilder<OptionValue> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .HasOne(e => e.Option)
                .WithMany(e => e.OptionValues)
                .HasForeignKey(e => e.OptionId)
                .HasPrincipalKey(e => e.Id);
        }
    }
}
