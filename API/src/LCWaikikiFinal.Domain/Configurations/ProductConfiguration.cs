using LCWaikikiFinal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LCWaikikiFinal.Domain.Configurations
{
        public class ProductConfiguration : IEntityTypeConfiguration<Product>
        {
                public void Configure(EntityTypeBuilder<Product> builder)
                {
                        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
                        builder.Property(x => x.AmountOfStock).IsRequired();
                        builder.Property(x => x.ImageUrl).IsRequired();
                        builder.Property(x => x.IsOfferable).IsRequired();
                        builder.Property(x => x.IsSold).IsRequired();
                        builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");

                        #region ForeingKey

                        builder.HasOne(i => i.ProductDetail)
                            .WithOne(i => i.Product)
                            .HasForeignKey<ProductDetail>(b => b.ProductId)
                            .OnDelete(DeleteBehavior.Cascade);

                        builder.HasMany(x => x.Offers)
                            .WithOne(x => x.Product)
                            .HasForeignKey(x => x.ProductId)
                            .OnDelete(DeleteBehavior.Cascade);

                        #endregion
                }
        }
}
