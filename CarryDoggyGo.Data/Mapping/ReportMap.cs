using CarryDoggyGo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryDoggyGo.Data.Mapping
{
    class ReportMap : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Reports");
            builder.HasKey(u => u.ReportId);
            builder.Property(u => u.ReportId)
               .ValueGeneratedOnAdd();

            builder.Property(u => u.Description)
                .HasMaxLength(300)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
