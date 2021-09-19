using System.Collections.Generic;
using PetShop.Core.Models;

namespace PetShop.Domain.IRepositories
{
    public interface IOwnerRepositories
    {
        List<Owner> GetAllOwner();
        Owner CreateOwner(Owner owner);
        string DeleteOwner(int ownerid);
        Owner UpdateOwner(Owner owner);
    }
}