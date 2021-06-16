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
    public class DogOwnerMap : IEntityTypeConfiguration<DogOwner>
    {
        public void Configure(EntityTypeBuilder<DogOwner> builder)
        {
            builder.ToTable("dog_owners");
            builder.HasKey(u => u.DogOwnerId);
            builder.Property(u => u.DogOwnerId)
               .HasColumnName("dog_owner_id")
               .ValueGeneratedOnAdd();

            builder.Property(u => u.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(u => u.LastName)
                .HasColumnName("lastname")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(u => u.Phone)
                .HasColumnName("phone")
                .HasMaxLength(9)
                .IsUnicode(false);

            builder.Property(u => u.Email)
               .HasColumnName("email")
               .IsRequired();

            builder.Property(u => u.Birthdate)
                .HasColumnName("birthdate")
                .IsRequired();

            builder.Property(u => u.Password)
                .HasColumnName("password")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(u => u.RegisterDate)
                .HasColumnName("resgister_at")
                .IsRequired();

            builder.Property(u => u.Address)
                .HasColumnName("address")
                .IsRequired();

            //builder.HasMany(dw => dw.DogWalks)
            //        .WithOne(dw => dw.DogOwner)
            //        .HasForeignKey(dw => dw.DogOwnerId);

            //by gsinuiri
            builder.HasMany(dw => dw.DogOwnerNotifications)
                    .WithOne(dw => dw.DogOwner)
                    .HasForeignKey(dw => dw.DogOwnerId);

        }
    }
}
