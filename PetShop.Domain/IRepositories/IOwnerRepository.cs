using System.Collections.Generic;
using PetShop.Core.Models;

namespace PetShop.Domain.IRepositories
{
    public interface IOwnerRepositories
    {
        List<Owner> GetAllOwners();
        Owner CreateOwner(Owner owner);
        string DeleteOwner(int ownerId);
        Owner UpdateOwner(Owner owner);
    }
}