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
    class CalificationMap : IEntityTypeConfiguration<Calification>
    {

        public void Configure(EntityTypeBuilder<Calification> builder)
        {

            builder.ToTable("calification");
            builder.HasKey(u => u.CalificationId);
            builder.Property(u => u.CalificationId)
               .HasColumnName("calification_id")
               .ValueGeneratedOnAdd();
            builder.Property(dw => dw.Starts)
             .HasColumnName("starts").IsUnicode(false).IsRequired();


            builder.Property(dw => dw.Recomendations)
             .HasColumnName("description")
             .HasMaxLength(500)
             .IsUnicode(false);





        }





        }
}
