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
    class CareItemMap : IEntityTypeConfiguration<CareItem>
    {
        public void Configure(EntityTypeBuilder<CareItem> builder)
        {
            builder.ToTable("care_item");
            builder.HasKey(u => u.CareItemId);
            builder.Property(u => u.CareItemId)
               .HasColumnName("care_item_id")
               .ValueGeneratedOnAdd();

            builder.Property(u => u.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();
            builder.Property(dw => dw.Description)
              .HasColumnName("description")
              .HasMaxLength(500)
              .IsUnicode(false);
        }
    }
}
