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
    public class DogWalkMap : IEntityTypeConfiguration<DogWalk>
    {
        public void Configure(EntityTypeBuilder<DogWalk> builder)
        {
            builder.ToTable("dog_walk");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("dog_walk_id")
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Hours)
                .HasColumnName("cantidad_horas")
                .IsRequired();

            builder.Property(u => u.AditionalInformation)
                .HasColumnName("aditional_information")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(u => u.PaymentAmount)
                .HasColumnName("payment_amount")
                .IsRequired();

            builder.Property(u => u.Calification)
                .HasColumnName("calification")
                .IsRequired();

            builder.Property(u => u.DogWalkerId)
                .HasColumnName("dog_walker_id")
                .IsRequired();

            builder.HasOne(u => u.DogWalker)
                .WithMany(u => u.DogWalks)
                .HasForeignKey(u => u.DogWalkerId)
                .HasConstraintName("fk_dog_walk_dog_walker")
                .IsRequired();

            builder.Property(u => u.DogOwnerId)
                .HasColumnName("dog_owner_id")
                .IsRequired();

            builder.HasOne(u => u.DogOwner)
                .WithMany(u => u.DogWalks)
                .HasForeignKey(u => u.DogOwnerId)
                .HasConstraintName("fk_dog_walk_dog_owner")
                .IsRequired();

            builder.Property(u => u.Date)
                .HasColumnName("date")
                .IsRequired();

            builder.Property(u => u.Address)
                .HasColumnName("address")
                .HasMaxLength(500)
                .IsUnicode(false);

        }
    }
}
