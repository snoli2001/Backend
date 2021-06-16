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
    public class LocationMap : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("locations");
            builder.HasKey(l => l.LocationId);

            builder.Property(l => l.LocationId)
               .HasColumnName("location_id")
               .ValueGeneratedOnAdd();

            builder.Property(l => l.Address)
                .HasColumnName("address")
                .HasMaxLength(500)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(l => l.NumX)
                .HasColumnName("position_x")
                .IsRequired();

            builder.Property(l => l.NumY)
                .HasColumnName("position_y")
                .IsRequired();

            //builder.Property(l => l.DistrictId)
            //       .HasColumnName("district_id");

            //builder.HasOne(l => l.District)
            //    .WithMany(ld => ld.Locations)
            //    .HasForeignKey(l => l.DistrictId)
            //    .HasConstraintName("FK_district_id");
            
        }
    }
}
