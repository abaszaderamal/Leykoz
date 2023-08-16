using Leykoz.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leykoz.Data.Configurations
{
    public class SiteSettingConfig : IEntityTypeConfiguration<SiteSetting>
    {
        public void Configure(EntityTypeBuilder<SiteSetting> builder)
        {
            builder.Property(p => p.Key).IsRequired();
            builder.Property(p => p.Value).IsRequired();
        }
    }
}