using System.Linq;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;
using PetShop.EFCore.Entities;

namespace PetShop.EFCore.Repositories
{
    public class InsuranceRepository : IInsuranceRepository
    {
        private readonly PetShopDBContext _ctx;

        public InsuranceRepository(PetShopDBContext ctx)
        {
            _ctx = ctx;
        }

        public Insurance GetById(int id)
        {
            return _ctx.Insurance
                .Select(ie =>new Insurance()
                {
                    Id = ie.Id,
                    Name = ie.Name,
                    Price = ie.Price
                })
                .FirstOrDefault(i => i.Id == id);
        }

        public Insurance CreateInsurance(Insurance insurance)
        {
            
            var entity = _ctx.Add(new InsuranceEntity(){
                Name = insurance.Name,
                Price = insurance.Price
            }).Entity;
            _ctx.SaveChanges();
            return new Insurance {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };
        }
    }
}