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
    class DogCareItemMap : IEntityTypeConfiguration<DogCareItem>
    {
        public void Configure(EntityTypeBuilder<DogCareItem> builder)
        {
            builder.ToTable("dog_care_items");
            builder.HasKey(pt => new { pt.DogId, pt.CareItemId});


            builder
                .HasOne(pt => pt.Dog)
                .WithMany(p => p.DogCareItems)
                .HasForeignKey(pt => pt.DogId);

            builder
                .HasOne(pt => pt.CareItem)
                .WithMany(t => t.DogCareItems)
                .HasForeignKey(pt => pt.CareItemId);
        }
    }
}
