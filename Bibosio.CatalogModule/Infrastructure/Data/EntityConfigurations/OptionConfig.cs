using Bibosio.CatalogModule.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bibosio.CatalogModule.Infrastructure.Data.EntityConfigurations
{
    internal class OptionConfig : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder
                .HasKey(x => x.Id);
        }
    }
}
