using Leykoz.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leykoz.Data.Configurations
{
    public class ProductConfig:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p=>p.Title).IsRequired();
            builder.Property(p => p.Description).IsRequired(false);
            builder.Property(p => p.Price).IsRequired().HasDefaultValue(0).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Count).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
            // builder.Property(p => p.DiscountPercent).IsRequired().HasDefaultValue(0).HasColumnType("decimal(18,2)");
            builder.Property(p =>p.ImageURL).IsRequired();
            // builder.Ignore(p =>p.Photo);
            // builder.Property(p => p.Discount).HasDefaultValue(false);
            // builder.Property(p => p.IsNew).HasDefaultValue(false);
            builder.Property(p => p.CreatedAt).IsRequired();
        }
    }
}