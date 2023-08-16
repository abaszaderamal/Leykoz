using Leykoz.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leykoz.Data.Configurations
{
    public class ReportAmountConfig:IEntityTypeConfiguration<ReportAmount>
    {
        public void Configure(EntityTypeBuilder<ReportAmount> builder)
        {
            builder.Property(r => r.IsDeleted).HasDefaultValue(false);
        }
    }
}