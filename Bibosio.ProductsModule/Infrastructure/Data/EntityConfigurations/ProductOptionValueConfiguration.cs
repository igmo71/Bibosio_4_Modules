using Bibosio.ProductsModule.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bibosio.ProductsModule.Infrastructure.Data.EntityConfigurations
{
    internal class ProductOptionValueConfiguration : IEntityTypeConfiguration<ProductOptionValue>
    {
        public void Configure(EntityTypeBuilder<ProductOptionValue> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.OptionId, x.ValueId });
        }
    }
}
