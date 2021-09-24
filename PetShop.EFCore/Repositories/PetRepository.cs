using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;
using PetShop.EFCore.Entities;

namespace PetShop.EFCore.Repositories
{
    public class PetRepository : IPetRepositories
    {
        private readonly PetShopDbContext _ctx;

        public PetRepository(PetShopDbContext ctx)
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
                    Type = new PetType(){Id = pet.PetType.Id, Name = pet.PetType.Name,},
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
                PetTypeId = pet.Type.Id,
                BirthDate = pet.BirthDate,
                SoldDate = pet.SoldDate,
                Color = pet.Color,
                Price = pet.Price,
                InsuranceId = pet.Insurance.Id
                
            }).Entity;
            _ctx.SaveChanges();
            return new Pet
            {
                Id = entity.Id,
                Name = entity.Name,
                Type = new PetType(){Id = entity.PetTypeId},
                BirthDate = entity.BirthDate,
                SoldDate = entity.SoldDate,
                Color = entity.Color,
                Price = entity.Price,
                Insurance = new Insurance(){Id = entity.InsuranceId}
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
                PetTypeId = pet.Type.Id,
                BirthDate = pet.BirthDate,
                SoldDate = pet.SoldDate,
                Color = pet.Color,
                Price = pet.Price,
                InsuranceId = pet.Insurance.Id
            };
            var entity = _ctx.Update(petEntity).Entity;
            _ctx.SaveChanges();
            return new Pet()
            {
                Id = entity.Id,
                Name = entity.Name,
                Type = new PetType(){Id = entity.PetTypeId},
                BirthDate = entity.BirthDate,
                SoldDate = entity.SoldDate,
                Color = entity.Color,
                Price = entity.Price,
                Insurance = new Insurance(){Id = entity.InsuranceId}
            };
        }
    }
}