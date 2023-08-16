using Leykoz.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leykoz.Data.Configurations
{
    public class InfoSlideConfig : IEntityTypeConfiguration<InfoSlide>
    {
        public void Configure(EntityTypeBuilder<InfoSlide> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Contetnt).IsRequired();
            builder.Property(p => p.MsgContetnt).IsRequired();
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.İsDeleted).HasDefaultValue(false);
            builder.Property(p => p.ImageFile).IsRequired();
            builder.Property(p => p.MsgTitleContetnt).IsRequired();
        }
    }
}