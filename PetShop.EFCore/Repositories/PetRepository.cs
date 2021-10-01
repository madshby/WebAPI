using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.Filtering;
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

        public List<Pet> GetAllPets(Filter filter)
        {
            var selectQuery = _ctx.Pets.Select(pet => new Pet()
            {
                Id = pet.Id,
                Name = pet.Name,
                Type = new PetType() {Id = pet.PetType.Id, Name = pet.PetType.Name,},
                BirthDate = pet.BirthDate,
                SoldDate = pet.SoldDate,
                Color = pet.Color,
                Price = pet.Price,
                Insurance = new Insurance()
                    {Id = pet.InsuranceId, Name = pet.Insurance.Name, Price = pet.Insurance.Price}
            });

            if (filter.OrderDir.ToLower().Equals("asc"))
            {
                switch (filter.OrderBy.ToLower())
                {
                    case "name":
                        selectQuery = selectQuery.OrderBy(pet => pet.Name);
                        break;
                    case "id":
                        selectQuery = selectQuery.OrderBy(pet => pet.Id);
                        break;
                }
            }
            else
            {
                selectQuery = selectQuery.OrderByDescending(pet => pet.Name);
            }

            var query = selectQuery
                .Skip((filter.Page - 1) * filter.Limit)
                .Take(filter.Limit);

            return selectQuery.ToList();
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
                Type = new PetType() {Id = entity.PetTypeId},
                BirthDate = entity.BirthDate,
                SoldDate = entity.SoldDate,
                Color = entity.Color,
                Price = entity.Price,
                Insurance = new Insurance() {Id = entity.InsuranceId}
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
                Type = new PetType() {Id = entity.PetTypeId},
                BirthDate = entity.BirthDate,
                SoldDate = entity.SoldDate,
                Color = entity.Color,
                Price = entity.Price,
                Insurance = new Insurance() {Id = entity.InsuranceId}
            };
        }

        public int TotalCount()
        {
            return _ctx.Pets.Count();
        }
    }
}