using LCWaikikiFinal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LCWaikikiFinal.Domain.Configurations
{
        public class SizeConfiguration : IEntityTypeConfiguration<Size>
        {
                public void Configure(EntityTypeBuilder<Size> builder)
                {
                        builder.Property(x => x.Name).HasMaxLength(8).IsRequired();

                        #region ForeingKey

                        builder.HasMany(x => x.Products)
                                    .WithOne(x => x.Size)
                                    .HasForeignKey(x => x.SizeId)
                                    .OnDelete(DeleteBehavior.Restrict);

                        #endregion
                }
        }
}
