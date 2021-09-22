using Microsoft.EntityFrameworkCore;
using PetShop.EFCore.Entities;

namespace PetShop.EFCore
{
    public class PetShopDbContext : DbContext
    {
        public DbSet<InsuranceEntity> Insurance { get; set; }
        public DbSet<PetEntity> Pets { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }

        public PetShopDbContext(DbContextOptions<PetShopDbContext> options) : base(options) {}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetEntity>()
                .HasOne(petEntity => petEntity.Insurance)
                .WithMany(insuranceEntity => insuranceEntity.Pets);
            modelBuilder.Entity<OwnerEntity>()
                .HasMany(ownerEntity => ownerEntity.Pets)
                .WithOne( petEntity => petEntity.Owner);
            
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity() {Id = 1, Name = "BasicInsurance", Price = 99});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity() {Id = 2, Name = "PremiumInsurance", Price = 999});
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity() {Id = 3, Name = "ProInsurance", Price = 9999});
        }
    }
}