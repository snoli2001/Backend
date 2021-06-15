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
    public class DogWalkLocationMap : IEntityTypeConfiguration<DogWalkLocation>
    {
        public void Configure(EntityTypeBuilder<DogWalkLocation> builder)
        {
            builder.ToTable("dogwalk_location");
            builder.HasKey(dl => new { dl.DogWalkId, dl.LocationId});

            builder.Property(dl => dl.DogWalkId)
               .HasColumnName("dogwalk_id");

            builder.Property(dl => dl.LocationId)
               .HasColumnName("location_id");

            builder.Property(dl => dl.DateRegister)
               .HasColumnName("date_register")
               .IsRequired();

            builder.HasOne(dl => dl.DogWalk)
                .WithMany(dw => dw.DogWalkLocations)
                .HasForeignKey(dl => dl.DogWalkId)
                .HasConstraintName("FK_dogwalk_id");

            builder.HasOne(dl => dl.Location)
                .WithMany(l => l.DogWalkLocations)
                .HasForeignKey(dl => dl.LocationId)
                .HasConstraintName("FK_location_id");

        }
    }
}
