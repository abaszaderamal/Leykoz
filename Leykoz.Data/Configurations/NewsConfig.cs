using Leykoz.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leykoz.Data.Configurations
{
    public class NewsConfig : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            //.HasMaxLength(255);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Contetnt).IsRequired();
            builder.Property(p => p.ImageFile).IsRequired();
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
        }
    }
}