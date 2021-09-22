using System;
using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;
using PetShop.EFCore.Entities;

namespace PetShop.EFCore.Repositories
{
    public class PetRepository : IPetRepositories
    {
        private readonly PetShopDBContext _ctx;

        public PetRepository(PetShopDBContext ctx)
        {
            _ctx = ctx;
        }

        public List<Pet> GetAllPets()
        {
            return _ctx.Pets
                .Select(pet => new Pet()
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    Type = pet.Type,
                    BirthDate = pet.BirthDate,
                    SoldDate = pet.SoldDate,
                    Color = pet.Color,
                    Price = pet.Price
                })
                .ToList();
        }

        public Pet Create(Pet pet)
        {
            var entity = _ctx.Add(new PetEntity()
            {
                Name = pet.Name,
                Type = pet.Type,
                BirthDate = pet.BirthDate,
                SoldDate = pet.SoldDate,
                Color = pet.Color,
                Price = pet.Price
            }).Entity;
            _ctx.SaveChanges();
            return new Pet
            {
                Id = entity.Id,
                Name = entity.Name,
                Type = entity.Type,
                BirthDate = entity.BirthDate,
                SoldDate = entity.SoldDate,
                Color = entity.Color,
                Price = entity.Price
            };
        }

        public string Delete(int petId)
        {
            _ctx.Remove(new PetEntity {Id = petId});
            _ctx.SaveChanges();

            return "Deleted";
        }

        public Pet UpdatePet(Pet pet)
        {
            var petEntity = new PetEntity()
            {
                Id = pet.Id,
                Name = pet.Name,
                Price = pet.Price
            };
            var entity = _ctx.Update(petEntity).Entity;
            _ctx.SaveChanges();
            return new Pet()
            {
                Id = entity.Id,
                Name = entity.Name,
                Type = entity.Type,
                BirthDate = entity.BirthDate,
                SoldDate = entity.SoldDate,
                Color = entity.Color,
                Price = entity.Price
            };
        }
    }
}