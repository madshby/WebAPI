using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepositories
    {   
        private static List<Owner> _ownerTable = new List<Owner>();
        private static int OwnerId = 1;
        private string deletedOwnerName;

        public OwnerRepository()
        {
            Owner owner1 = new Owner()
            {
                Id = OwnerId,
                Name = "Den Hvide Mester"
            };
            CreateOwner(owner1);
        }
        
        public List<Owner> GetAllOwner()
        {
            return _ownerTable;
        }

        public Owner CreateOwner(Owner owner)
        {
            owner.Id = OwnerId++;
            _ownerTable.Add(owner);
            return owner;
        }

        public string DeleteOwner(int ownerid)
        {
            _ownerTable = GetAllOwner();
            foreach (var owner in _ownerTable.ToList())
            {
                if (ownerid == owner.Id)
                {
                    _ownerTable.Remove(owner);
                    deletedOwnerName = owner.Name;
                }
            }
            return deletedOwnerName;
        }

        public Owner UpdateOwner(Owner owner)
        {
            var OwnerToUpdate = _ownerTable.FirstOrDefault(o => o.Id == owner.Id);
            if (OwnerToUpdate != null)
            {
                OwnerToUpdate.Name = owner.Name;
            }

            return OwnerToUpdate;
        }
    }
}