﻿using CarryDoggyGo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryDoggyGo.Data.Mapping
{
    class QualificationMap : IEntityTypeConfiguration<Qualification>
    {

        public void Configure(EntityTypeBuilder<Qualification> builder)
        {

            builder.ToTable("qualification");
            builder.HasKey(u => u.QualificationId);
            builder.Property(u => u.QualificationId)
               .HasColumnName("qualification_id")
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