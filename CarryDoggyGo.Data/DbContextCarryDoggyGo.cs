using CarryDoggyGo.Data.Mapping;
using CarryDoggyGo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryDoggyGo.Data
{
    public class DbContextCarryDoggyGo : DbContext
    {
        public DbContextCarryDoggyGo(DbContextOptions<DbContextCarryDoggyGo> options): base(options)
        {
        }
        public DbSet<DogOwner> DogOwners  { get; set; }
        public DbSet<DogWalker> DogWalkers { get; set; }
        public DbSet<Dog> Dogs{ get; set; }
        public DbSet<DogCareItem> DogCareItems{ get; set; }
        public DbSet<CareItem> CareItems{ get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<NotificationDogWalker> NotificationDogWalkers { get; set; }
        public DbSet<DogOwnerNotification> DogOwnerNotifications { get; set; }
        public DbSet<DogWalkDog> DogWalkDogs { get; set; }
        public DbSet<DogWalk> DogWalks { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<DogWalkLocation> DogWalkLocations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<DogWalkerDistrict> DogWalkerDistricts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DogOwnerMap());
            modelBuilder.ApplyConfiguration(new DogWalkerMap());
            modelBuilder.ApplyConfiguration(new DogCareItemMap());
            modelBuilder.ApplyConfiguration(new DogMap());
            modelBuilder.ApplyConfiguration(new CareItemMap());
            modelBuilder.ApplyConfiguration(new QualificationMap());
            modelBuilder.ApplyConfiguration(new NotificationDogWalkerMap());
            modelBuilder.ApplyConfiguration(new DogWalkMap());
            modelBuilder.ApplyConfiguration(new DogWalkDogsMap());
            modelBuilder.ApplyConfiguration(new DogWalkMap());
            modelBuilder.ApplyConfiguration(new PaymentTypeMap());
            modelBuilder.ApplyConfiguration(new ReportMap());
            modelBuilder.ApplyConfiguration(new CityMap());
            modelBuilder.ApplyConfiguration(new DistrictMap());
            modelBuilder.ApplyConfiguration(new LocationMap());
            modelBuilder.ApplyConfiguration(new DogWalkLocationMap());
            modelBuilder.ApplyConfiguration(new MessageMap());
            modelBuilder.ApplyConfiguration(new DogWalkerDistrictMap());
        }
    }
}
