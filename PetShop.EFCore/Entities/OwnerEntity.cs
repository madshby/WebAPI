using System.Collections.Generic;

namespace PetShop.EFCore.Entities
{
    public class OwnerEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PetEntity> Pets;
    }
}