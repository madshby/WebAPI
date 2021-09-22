using System;
using PetShop.Core.Models;

namespace PetShop.EFCore.Entities
{
    public class PetEntity
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public PetType Type{ get; set; }
        public DateTime BirthDate{ get; set; }
        public DateTime SoldDate{ get; set; }
        public string Color{ get; set; }
        public double Price{ get; set; }
        public InsuranceEntity Insurance { get; set; }
        public int InsuranceId { get; set; }
    }
}