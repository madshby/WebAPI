using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.IServices;
using PetShop.Core.Models;

namespace PetShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public ActionResult<List<Owner>> getAllOwner()
        {
            return Ok(_ownerService.GetAllOwners());
        }

        [HttpGet("{id}")]
        //api/Pet/id
        //api/Pet/7
        public ActionResult<Pet> GetById(long id)
        {
            return StatusCode(501, "Vi er ikke klar endnu, ring igen senere bums");
        }

        [HttpPost]
        public ActionResult<Owner> CreateOwner([FromBody] Owner owner)
        {
            return Created($"https://localhost/api/Owner/{owner.Id}", _ownerService.CreateOwner(owner));
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteOwner(int id)
        {
            return _ownerService.DeleteOwner(id);
        }

        [HttpPut("{id}")]
        public ActionResult<Owner> PutOwner(int id, [FromBody] Owner owner)
        {
            return Ok(_ownerService.UpdatePetOwner(new Owner()
            {
                Id = id,
                Name = owner.Name,
            }));
        }
    }
}