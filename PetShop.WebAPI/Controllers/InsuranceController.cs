using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.IServices;
using PetShop.Core.Models;

namespace PetShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }
        
        [HttpGet("{id}")]
        public ActionResult<Insurance> GetById(int id)
        {
            try
            {
                return Ok(_insuranceService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Unexpected Error");
            }
        }

        [HttpPost]
        public ActionResult<Insurance> Create([FromBody] Insurance insurance)
        {
            try
            {
                return Ok(_insuranceService.CreateInsurance(insurance));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Unexpected Error");
            }
        }

        [HttpGet]
        public ActionResult<List<Insurance>> ReadAllInsurance()
        {
            try
            {
                return Ok(_insuranceService.ReadAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, "Unexpected Error");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteInsurance(int id)
        {
            try
            {
                return Ok(_insuranceService.DeleteInsuranceById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Unexpected Error");
            }
        }
        
        [HttpPut("{id}")]

        public ActionResult<Insurance> PutInsurance(int id, [FromBody] Insurance insurance)
        {
            try
            {
                if (id != insurance.Id)
                {
                    return BadRequest("ID must match the expected ID");
                }

                return Ok(_insuranceService.PutInsurance(insurance));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Unexpected Error");
            }
        }

    }
}