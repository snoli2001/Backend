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
               .ValueGeneratedOnAdd();

            builder.Property(d => d.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            //by gsinuiri
            builder.HasMany(dw => dw.DogOwners)
                    .WithOne(dw => dw.District)
                    .HasForeignKey(dw => dw.DistrictId);

            //by gsinuiri
            builder.HasMany(dw => dw.DogWalks)
                    .WithOne(dw => dw.District)
                    .HasForeignKey(dw => dw.DistrictId);
        }
    }
}
