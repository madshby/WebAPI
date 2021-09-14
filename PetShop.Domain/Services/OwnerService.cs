using System.Collections.Generic;
using PetShop.Core.IServices;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;

namespace PetShop.Domain.Services
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepositories _repo;

        public OwnerService(IOwnerRepositories repo)
        {
            _repo = repo;
        }

        public List<Owner> GetAllOwners()
        {
            return _repo.GetAllOwner();
        }

        public Owner CreateOwner(Owner owner)
        {
            return _repo.CreateOwner(owner);
        }

        public string DeleteOwner(int ownerid)
        {
            return _repo.DeleteOwner(ownerid);
        }

        public Owner UpdatePetOwner(Owner owner)
        {
            return _repo.UpdateOwner(owner);
        }
    }
}