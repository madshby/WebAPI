using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepositories
    {   
        private static List<Owner> _ownerTable = new List<Owner>();
        private static int _ownerId = 1;
        private string _deletedOwnerName;

        public OwnerRepository()
        {
            Owner owner1 = new Owner()
            {
                Id = _ownerId,
                Name = "McLovin"
            };
            CreateOwner(owner1);
        }
        
        public List<Owner> GetAllOwners()
        {
            return _ownerTable;
        }

        public Owner CreateOwner(Owner owner)
        {
            owner.Id = _ownerId++;
            _ownerTable.Add(owner);
            return owner;
        }

        public string DeleteOwner(int ownerid)
        {
            _ownerTable = GetAllOwners();
            foreach (var owner in _ownerTable.ToList())
            {
                if (ownerid == owner.Id)
                {
                    _ownerTable.Remove(owner);
                    _deletedOwnerName = owner.Name;
                }
            }
            return _deletedOwnerName;
        }

        public Owner UpdateOwner(Owner owner)
        {
            var ownerToUpdate = _ownerTable.FirstOrDefault(o => o.Id == owner.Id);
            if (ownerToUpdate != null)
            {
                ownerToUpdate.Name = owner.Name;
            }

            return ownerToUpdate;
        }
    }
}