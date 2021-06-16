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
    public class DistrictMap : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.ToTable("districts");
            builder.HasKey(d => d.DistrictId);

            builder.Property(d => d.DistrictId)
               .HasColumnName("district_id")
               .ValueGeneratedOnAdd();

            builder.Property(d => d.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(d => d.CityId)
               .HasColumnName("city_id");

            builder.HasOne(d => d.City)
                .WithMany(dc => dc.Districts)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_city_id");

        }
    }
}
