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
            builder.HasKey(u => u.DogWalkId);

            builder.Property(u => u.DogWalkId)
                .HasColumnName("dog_walk_id")
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Hours)
                .HasColumnName("hours")
                .IsRequired();

            builder.Property(u => u.AditionalInformation)
                .HasColumnName("aditional_information")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(u => u.PaymentAmount)
                .HasColumnName("payment_amount")
                .IsRequired();

            builder.HasOne(u => u.Qualification)
                .WithOne(u => u.DogWalk)
                .HasForeignKey<Qualification>(u => u.DogWalkId)
                .IsRequired();

            builder.HasOne(u => u.DogWalker)
                .WithMany(u => u.DogWalks)
                .HasForeignKey(u => u.DogWalkerId)
                .IsRequired();

            builder.Property(u => u.Date)
                .HasColumnName("date")
                .IsRequired();

            builder.Property(u => u.Address)
                .HasColumnName("address")
                .HasMaxLength(500)
                .IsUnicode(false);

            //by gsinuiri
            builder.HasOne(u => u.PaymentType)
                .WithMany(u => u.DogWalks)
                .HasForeignKey(u => u.PaymentTypeId)
                .IsRequired();

            //by gsinuiri
            builder.HasMany(dw => dw.Reports)
                    .WithOne(dw => dw.DogWalk)
                    .HasForeignKey(dw => dw.DogWalkId);

            //by gsinuiri
            builder.HasMany(dw => dw.Messages)
                    .WithOne(dw => dw.DogWalk)
                    .HasForeignKey(dw => dw.DogWalkId);
        }
    }
}
