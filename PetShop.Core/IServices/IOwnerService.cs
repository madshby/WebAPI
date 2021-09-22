using System.Collections.Generic;
using PetShop.Core.Models;

namespace PetShop.Core.IServices
{
    public interface IOwnerService
    {
        List<Owner> GetAllOwners();
        Owner CreateOwner(Owner owner);
        string DeleteOwner(int ownerId);
        Owner UpdatePetOwner(Owner owner);
    }
}