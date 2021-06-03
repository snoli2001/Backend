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
    public class NotificationDogWalkerMap : IEntityTypeConfiguration<NotificationDogWalker>
    {
        public void Configure(EntityTypeBuilder<NotificationDogWalker> builder)
        {
            builder.ToTable("notification_dogwalker");
            builder.HasKey(n => n.NotificationDogWalkerId);

            builder.Property(n => n.NotificationDogWalkerId)
               .HasColumnName("notification_dogwalker_id")
               .ValueGeneratedOnAdd();

            //builder.HasOne(n => n.DogWalker)
            //   .WithMany(n => n.NotificationDogWalkers)
            //   .HasForeignKey(n => n.DogWalkerId);

            builder.Property(n => n.DogWalkerId)
              .HasColumnName("dog_walker_id")
              .IsRequired();

            builder.Property(n => n.ShippingDate)
               .HasColumnName("shipping_date")
               .IsRequired();

            builder.Property(n => n.Description)
               .HasColumnName("description")
               .HasMaxLength(500)
               .IsUnicode(false)
               .IsRequired();

            builder.Property(n => n.AcceptDeny)
                   .HasColumnName("accept_deny")
                   .HasDefaultValueSql("((0))");
        }
    }
}
