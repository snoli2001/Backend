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
    public class DogWalkerMap : IEntityTypeConfiguration<DogWalker>
    {
        public void Configure(EntityTypeBuilder<DogWalker> builder)
        {
            builder.ToTable("dog_walkers");
            builder.HasKey(u => u.DogWalkerId);

            builder.Property(u => u.DogWalkerId)
                .HasColumnName("dog_walker_id")
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

            builder.Property(dw => dw.Description)
               .HasColumnName("description")
               .HasMaxLength(500)
               .IsUnicode(false);

            builder.Property(dw => dw.PaymentAmount)
               .HasColumnName("payment_amount")
               .IsUnicode(false);

            builder.Property(dw => dw.Qualification)
              .HasColumnName("Qualification");

            builder.HasMany(dw => dw.DogWalks)
                    .WithOne(dw => dw.DogWalker)
                    .HasForeignKey(dw => dw.DogWalkerId);
        }
    }
}
