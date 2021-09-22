using System;
using System.Collections.Generic;
using PetShop.Core.IServices;
using PetShop.Core.Models;
using PetShop.Domain.IRepositories;

namespace PetShop.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepositories _repo;
        private List<Pet> _petList = new List<Pet>();

        public PetService(IPetRepositories repo)
        {
            _repo = repo;
        }

        public List<Pet> GetAllPets()
        {
            return _repo.GetAllPets();
        }

        public List<Pet> GetPetsByType(string searchedWords)
        {
            List<Pet> searchedPets = new List<Pet>();
            _petList = GetAllPets();
            foreach (var pet in _petList)
            {
                if (String.Equals(pet.Type.Name, searchedWords, StringComparison.CurrentCultureIgnoreCase))
                {
                    searchedPets.Add(pet);
                }
            }
            return searchedPets;
        }

        public Pet Create(Pet pet)
        {
            return _repo.Create(pet);
        }

        public string Delete(int petId)
        {
            return _repo.Delete(petId);
        }

        public Pet UpdatePet(Pet pet)
        {
            return _repo.UpdatePet(pet);
        }
    }
}