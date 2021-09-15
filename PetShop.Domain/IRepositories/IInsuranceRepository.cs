using PetShop.Core.Models;

namespace PetShop.Domain.IRepositories
{
    public interface IInsuranceRepository
    {
        Insurance GetById(int id);
        Insurance CreateInsurance(Insurance insurance);
    }
}