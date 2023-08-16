using Leykoz.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leykoz.Data.Configurations
{
    public class ReportConfig:IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.Property(r => r.CreatedAt).IsRequired();
            builder.Property(r => r.IsDeleted).HasDefaultValue(false);
            // builder.Property(r => r.IsPublic).HasDefaultValue(false);
            // builder.HasOne(r => r.Savior).WithMany(r => r.Reports);
        }
    }
}