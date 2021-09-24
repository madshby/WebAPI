using System;

namespace PetShop.WebAPI.Dtos.Pets
{
    public class DeletePetDto
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string PetTypeName{ get; set; }
        public DateTime BirthDate{ get; set; }
        public DateTime SoldDate{ get; set; }
        public string Color{ get; set; }
        public double Price{ get; set; }
    }
}