using LCWaikikiFinal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LCWaikikiFinal.Domain.Configurations
{
        public class BrandConfiguration : IEntityTypeConfiguration<Brand>
        {
                public void Configure(EntityTypeBuilder<Brand> builder)
                {
                        builder.Property(x => x.Name).HasMaxLength(20).IsRequired();

                        #region ForeingKey

                        builder.HasMany(x => x.Products)
                                    .WithOne(x => x.Brand)
                                    .HasForeignKey(x => x.BrandId)
                                    .IsRequired(false)
                                    .OnDelete(DeleteBehavior.Restrict);

                        #endregion

                }
        }
}
