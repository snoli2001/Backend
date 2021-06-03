using CarryDoggyGo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//by gsinuiri
namespace CarryDoggyGo.Data.Mapping
{
    public class DogOwnerNotificatoinMap : IEntityTypeConfiguration<DogOwnerNotification>
    {
        public void Configure(EntityTypeBuilder<DogOwnerNotification> builder)
        {
            builder.ToTable("DogOwnerNotifications");
            builder.HasKey(u => u.DogOwnerNotificationId);
            builder.Property(u => u.DogOwnerNotificationId)
               .ValueGeneratedOnAdd();

            builder.Property(u => u.Description)
                .HasMaxLength(300)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(u => u.CreatedAt)
                .IsRequired();
        }
    }
}
