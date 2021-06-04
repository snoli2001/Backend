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
    public class DogMap : IEntityTypeConfiguration<Dog>
    {
        public void Configure(EntityTypeBuilder<Dog> builder)
        {
            builder.ToTable("dogs");
            builder.HasKey(u => u.DogId);
            builder.Property(u => u.DogId)
               .HasColumnName("dog_id")
               .ValueGeneratedOnAdd();

            builder.Property(u => u.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(u => u.MedicalInformation)
                .HasColumnName("medical_information");
            builder.Property(u => u.Race)
              .HasColumnName("race");

            builder.Property(dw => dw.Description)
              .HasColumnName("description")
              .HasMaxLength(500)
              .IsUnicode(false);

            builder.Property(dw => dw.Diseases)
                 .HasColumnName("diseases")
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}
