using System;
using System.Collections.Generic;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;

namespace PetShop.EFCore.Repositories
{
    public class OwnerRepository1 : IOwnerRepositories
    {
        private readonly PetShopDBContext _ctx;

        public OwnerRepository1(PetShopDBContext ctx)
        {
            _ctx = ctx;
        }
        
       public List<Owner> GetAllOwner()
        {
          //  return _ctx.Pets
            //    .Select(pet => new Pet()
              //  {
               //     Id = pet.Id,
                //    Name = pet.Name,
                 //   Type = pet.Type,
                  //  BirthDate = pet.BirthDate,
                  //  SoldDate = pet.SoldDate,
                   // Color = pet.Color,
                   // Price = pet.Price
               // })
              //  .ToList();
              throw new NotImplementedException();
        }

        public Owner CreateOwner(Owner owner)
        {
            throw new System.NotImplementedException();
        }

        public string DeleteOwner(int ownerid)
        {
            throw new System.NotImplementedException();
        }

        public Owner UpdateOwner(Owner owner)
        {
            throw new System.NotImplementedException();
        }
    }
}