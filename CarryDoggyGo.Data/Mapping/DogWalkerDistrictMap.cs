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
    public class DogWalkerDistrictMap : IEntityTypeConfiguration<DogWalkerDistrict>
    {
        public void Configure(EntityTypeBuilder<DogWalkerDistrict> builder)
        {
            builder.ToTable("DogWalkerDistricts");
            builder.HasKey(pt => new { pt.DogWalkerkId, pt.DistrictId });

            builder.HasOne(pt => pt.DogWalker)
                .WithMany(p => p.DogWalkerDistricts)
                .HasForeignKey(pt => pt.DogWalkerkId);

            builder.HasOne(pt => pt.District)
                .WithMany(p => p.DogWalkerDistricts)
                .HasForeignKey(pt => pt.DistrictId);
        }
    }
}
