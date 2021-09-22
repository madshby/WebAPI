namespace PetShop.EFCore.Entities
{
    public class OwnerEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PetEntity Pet { get; set; }
        public int petId { get; set; }
    }
}