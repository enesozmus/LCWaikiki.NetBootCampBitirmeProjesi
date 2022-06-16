using LCWaikikiFinal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LCWaikikiFinal.Domain.Configurations
{
        public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
        {
                public void Configure(EntityTypeBuilder<ProductDetail> builder)
                {
                        builder.Property(x => x.ShortDescription).HasMaxLength(100);
                        builder.Property(x => x.LongDescription).HasMaxLength(500);
                        builder.Property(x => x.Fabric).HasMaxLength(25);
                        builder.Property(x => x.Pattern).HasMaxLength(25);
                        builder.Property(x => x.UnitWeight).HasColumnType("decimal(18,2)");
                }
        }
}
