using LCWaikikiFinal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LCWaikikiFinal.Domain.Configurations
{
        public class OfferConfiguration : IEntityTypeConfiguration<Offer>
        {
                public void Configure(EntityTypeBuilder<Offer> builder)
                {
                        builder.Property(x => x.OfferPrice).IsRequired();
                }
        }
}
