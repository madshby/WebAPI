using System;
using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;
using PetShop.EFCore.Entities;

namespace PetShop.EFCore.Repositories
{
    public class OwnerRepository : IOwnerRepositories
    {
        private readonly PetShopDbContext _ctx;

        public OwnerRepository(PetShopDbContext ctx)
        {
            _ctx = ctx;
        }
        
       public List<Owner> GetAllOwners()
       {
           return _ctx.Owners
               .Select(owner => new Owner()
               {
                   Id = owner.Id,
                   Name = owner.Name
               })
               .ToList();
       }

        public Owner CreateOwner(Owner owner)
        {
            var entity = _ctx.Add(new OwnerEntity()
            {
                Name = owner.Name
            }).Entity;
            _ctx.SaveChanges();
            return new Owner()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public string DeleteOwner(int ownerId)
        {
            _ctx.Remove(new Owner {Id = ownerId});
            _ctx.SaveChanges();

            return "Deleted";
        }

        public Owner UpdateOwner(Owner owner)
        {
            var ownerEntity = new OwnerEntity()
            {
                Id = owner.Id,
                Name = owner.Name
            };
            var entity = _ctx.Update(ownerEntity).Entity;
            _ctx.SaveChanges();
            return new Owner()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}