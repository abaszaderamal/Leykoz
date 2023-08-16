using Leykoz.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leykoz.Data.Configurations
{
    public class TargetConfig : IEntityTypeConfiguration<Target>
    {
        public void Configure(EntityTypeBuilder<Target> builder)
        {
            builder
                .Property(p => p.Content)
                .IsRequired();
            builder
                .Property(p => p.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}