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
    class PaymentTypeMap : IEntityTypeConfiguration<PaymentType> 
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.ToTable("PaymentTypes");
            builder.HasKey(u => u.PaymentTypeId);
            builder.Property(u => u.PaymentTypeId)
               .IsRequired().ValueGeneratedOnAdd();

            builder.Property(u => u.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsRequired();

            builder.HasMany(dw => dw.DogWalks)
                .WithOne(dw => dw.PaymentType)
                .HasForeignKey(dw => dw.PaymentTypeId);
        }
    }
}
