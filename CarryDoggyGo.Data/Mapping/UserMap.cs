//using CarryDoggyGo.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CarryDoggyGo.Data.Mapping
//{
//    public class UserMap : IEntityTypeConfiguration<User>
//    {
//        public void Configure(EntityTypeBuilder<User> builder)
//        {
//            builder.ToTable("users")
//                .HasDiscriminator<int>("User_type")
//                .HasValue<DogOwner>(1)
//                .HasValue<DogWalker>(2);

//            builder.HasKey(u => u.UserId);

//            builder.Property(u => u.UserId)
//                .HasColumnName("user_id")
//                .ValueGeneratedOnAdd();

//            builder.Property(u => u.Name)
//                .HasColumnName("name")
//                .HasMaxLength(50)
//                .IsUnicode(false)
//                .IsRequired();

//            builder.Property(u => u.LastName)
//                .HasColumnName("lastname")
//                .HasMaxLength(50)
//                .IsUnicode(false)
//                .IsRequired();
            
//            builder.Property(u => u.Phone)
//                .HasColumnName("phone")
//                .HasMaxLength(9)
//                .IsUnicode(false);
            
//            builder.Property(u => u.Email)
//               .HasColumnName("email")
//               .IsRequired();
            
//            builder.Property(u => u.Birthdate)
//                .HasColumnName("birthdate")
//                .IsRequired();
            
//            builder.Property(u => u.Password)
//                .HasColumnName("password")
//                .HasMaxLength(20)
//                .IsRequired();

//            builder.Property(u => u.RegisterDate)
//                .HasColumnName("birthdate")
//                .IsRequired();
//        }
//    }
//}
