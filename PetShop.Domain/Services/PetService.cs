using System;
using System.Collections.Generic;
using PetShop.Core.Filtering;
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

        public List<Pet> GetAllPets(Filter filter)
        {
            if (filter == null || filter.Limit <= 0 || filter.Limit > 100)
            {
                throw new ArgumentException("Filter limit must be above 0 and below 100");
            }

            var totalCount = TotalCount();
            var maxPageCount = Math.Ceiling((double)totalCount / filter.Limit);
            if (filter.Page < 1 || filter.Page > maxPageCount)
            {
                throw new ArgumentException($"Filter Limit must be between 1 and {maxPageCount}");
            }
            return _repo.GetAllPets(filter);
        }

        public List<Pet> GetPetsByType(string searchedWords)
        {
            var filter = new Filter();
            List<Pet> searchedPets = new List<Pet>();
            _petList = GetAllPets(filter);
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

        public int TotalCount()
        {
            return _repo.TotalCount();
        }
    }
}