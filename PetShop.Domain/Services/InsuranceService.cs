using System.Collections.Generic;
using PetShop.Core.IServices;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;

namespace PetShop.Domain.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IInsuranceRepository _insuranceRepository;

        public InsuranceService(IInsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;
        }

        public Insurance GetById(int id)
        {
            return _insuranceRepository.GetById(id);
        }

        public Insurance CreateInsurance(Insurance insurance)
        {
            return _insuranceRepository.CreateInsurance(insurance);
        }

        public List<Insurance> ReadAll()
        {
            return _insuranceRepository.ReadAll();
        }

        public string DeleteInsuranceById(int id)
        {
            return _insuranceRepository.DeleteInsuranceById(id);
        }

        public Insurance PutInsurance(Insurance insurance)
        {
            return _insuranceRepository.UpdateInsurance(insurance);
        }
    }
}