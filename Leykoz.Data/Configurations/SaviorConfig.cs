using System;
using Leykoz.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leykoz.Data.Configurations
{
    public class SaviorConfig : IEntityTypeConfiguration<Savior>
    {
        public void Configure(EntityTypeBuilder<Savior> builder)
        {
            builder.Property(p => p.FullName).IsRequired();
            builder.Property(p => p.ApplyContent).IsRequired();
            builder.Property(p => p.ApplyType).IsRequired();
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Phone).IsRequired();
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
        }
    }
}