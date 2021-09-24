using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.IServices;
using PetShop.Core.Models;
using PetShop.WebAPI.Dtos.Pets;

namespace PetShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public ActionResult<List<GetAllPetsDto>> GetAllPets()
        {
            return Ok(_petService.GetAllPets()
                .Select(pet => new GetAllPetsDto()
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    PetTypeName = pet.Type.Name,
                    BirthDate = pet.BirthDate,
                    SoldDate = pet.SoldDate,
                    Color = pet.Color,
                    Price = pet.Price,
                    InsuranceName = pet.Insurance.Name
                }));
        }

        [HttpGet("{id}")]
        
        public ActionResult<Pet> GetById(long id)
        {
            return StatusCode(501, "Unexpected Error");
        }

        [HttpPost]
        public ActionResult<CreatePetDto> CreatePet([FromBody]Pet pet)
        {
            return Created($"https://localhost/api/Pet/{pet.Id}",_petService.Create(pet));
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeletePet(int id)
        {
            return _petService.Delete(id);
        }

        [HttpPut("{id}")]
        public ActionResult<Pet> PutPet( int id, [FromBody]Pet pet)
        {
            return Ok(_petService.UpdatePet(new Pet()
            {
                Id = id,
                Name = pet.Name,
                Type = pet.Type,
                BirthDate = pet.BirthDate,
                SoldDate = pet.SoldDate,
                Color = pet.Color,
                Price = pet.Price
            }));
        }
    }
}