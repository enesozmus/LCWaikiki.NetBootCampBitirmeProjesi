using LCWaikikiFinal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LCWaikikiFinal.Domain.Configurations
{
        public class LifecycleConfiguration : IEntityTypeConfiguration<Lifecycle>
        {
                public void Configure(EntityTypeBuilder<Lifecycle> builder)
                {
                        builder.Property(x => x.Description).HasMaxLength(20).IsRequired();

                        #region ForeingKey

                        builder.HasMany(x => x.Products)
                                    .WithOne(x => x.Lifecycle)
                                    .HasForeignKey(x => x.LifecycleId)
                                    .OnDelete(DeleteBehavior.Restrict);

                        #endregion
                }
        }
}
