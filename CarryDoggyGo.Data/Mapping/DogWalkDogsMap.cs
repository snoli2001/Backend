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
    class DogWalkDogsMap : IEntityTypeConfiguration<DogWalkDog>
    {
        public void Configure(EntityTypeBuilder<DogWalkDog> builder)
        {
            builder.ToTable("dog_walk_dog");
            builder.HasKey(pt => new { pt.DogId, pt.DogWalkId });
            builder.Property(dwd => dwd.DogId).HasColumnName("dog_id");
            builder.Property(dwd => dwd.DogWalkId).HasColumnName("dog_walk_id");

            builder
                .HasOne(pt => pt.Dog)
                .WithMany(p => p.DogWalkDogs)
                .HasForeignKey(p => p.DogId)
                .HasConstraintName("FK_dog_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(pt => pt.DogWalk)
                .WithMany(t => t.DogWalkDogs)
                .HasForeignKey(pt => pt.DogWalkId)
                .HasConstraintName("FK_dog_walk_id")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
