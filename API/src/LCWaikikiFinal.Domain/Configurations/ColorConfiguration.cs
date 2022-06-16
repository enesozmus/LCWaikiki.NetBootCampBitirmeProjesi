using LCWaikikiFinal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LCWaikikiFinal.Domain.Configurations
{
        public class ColorConfiguration : IEntityTypeConfiguration<Color>
        {
                public void Configure(EntityTypeBuilder<Color> builder)
                {
                        builder.Property(x => x.Name).HasMaxLength(20).IsRequired();

                        #region ForeingKey

                        builder.HasMany(x => x.Products)
                                    .WithOne(x => x.Color)
                                    .HasForeignKey(x => x.ColorId)
                                    .IsRequired(false)
                                    .OnDelete(DeleteBehavior.Restrict);

                        #endregion

                }
        }
}
