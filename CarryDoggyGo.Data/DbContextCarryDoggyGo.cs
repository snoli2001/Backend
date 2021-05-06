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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DogOwnerMap());
            modelBuilder.ApplyConfiguration(new DogWalkerMap());
            modelBuilder.ApplyConfiguration(new DogCareItemMap());
            modelBuilder.ApplyConfiguration(new DogMap());
            modelBuilder.ApplyConfiguration(new CareItemMap());

        }

    }
}
