using Microsoft.EntityFrameworkCore;
using PetShop.Core.Models;
using PetShop.EFCore.Entities;

namespace PetShop.EFCore
{
    public class PetShopDbContext : DbContext
    {
        public DbSet<InsuranceEntity> Insurances { get; set; }
        public DbSet<PetEntity> Pets { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }

        public PetShopDbContext(DbContextOptions<PetShopDbContext> options) : base(options) {}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //A Pet can have one insurance and an insurance can have many pets
            modelBuilder.Entity<PetEntity>()
                .HasOne(petEntity => petEntity.Insurance)
                .WithMany(insuranceEntity => insuranceEntity.Pets);
            
            //A Pet can have one PetType and a PetType can have many pets
            modelBuilder.Entity<PetEntity>()
                .HasOne(petEntity => petEntity.PetType)
                .WithMany(petTypeEntity => petTypeEntity.Pets);
            
            //An Owner can have many pets, but pets can only have one owner
            modelBuilder.Entity<OwnerEntity>()
                .HasMany(ownerEntity => ownerEntity.Pets)
                .WithOne( petEntity => petEntity.Owner);
            
            //Mock Data Insurance
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity() {Id = 1, Name = "BasicInsurance", Price = 99});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity() {Id = 2, Name = "PremiumInsurance", Price = 999});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity() {Id = 3, Name = "ProInsurance", Price = 9999});
        }
    }
}