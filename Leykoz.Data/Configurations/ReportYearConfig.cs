using Leykoz.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leykoz.Data.Configurations
{
    public class ReportYearConfig:IEntityTypeConfiguration<ReportYear>
    {
        public void Configure(EntityTypeBuilder<ReportYear> builder)
        {
            builder.Property(r => r.IsDeleted).HasDefaultValue(false);
        }
    }
}