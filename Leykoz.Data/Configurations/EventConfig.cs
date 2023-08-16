using Leykoz.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leykoz.Data.Configurations
{
    public class EventConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(p => p.Content).IsRequired();
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
        }
    }
}