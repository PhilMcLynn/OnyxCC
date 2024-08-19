using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DOMAIN = Onyx.Product.Domain.Entities;

namespace Onyx.Product.Persistence.Configuartions
{
    public class ProductConfiguration : IEntityTypeConfiguration<DOMAIN.Product>
    {
        public void Configure(EntityTypeBuilder<DOMAIN.Product> builder) 
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
