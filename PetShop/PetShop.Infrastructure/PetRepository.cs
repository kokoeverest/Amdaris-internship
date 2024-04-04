
using System.Linq;
using PetShop.Domain.Enums;
using PetShop.Domain.Models;
using PetShop.Infrastructure.Abstractions;

namespace PetShop.Infrastructure
{
    public class PetRepository : IPetsRepository
    {
        private List<Pet> _pets = [];

        public Pet Create(Pet pet)
        {
            _pets.Add(pet);
            return pet;
        }

        public List<Pet> GetAll()
        {
            return _pets;
        }

        public int GetLastId()
        {
            int firstId = 1;
            return _pets.LastOrDefault()?.Id + 1 ?? firstId;
        }

        public Pet GetPetById(int id)
        {
            for (int i = 0; i < _pets.Count; i++)
            {
                if (_pets[i].Id == id)
                {
                    return _pets.ElementAt(i);
                }
            }
            throw new ApplicationException($"Pet with id {id} not found");
        }

        public List<Pet> GetPetsBySex(SexEnum sex)
        {
            return _pets.Where(pet => pet.Sex == sex).ToList();
        }

        public List<Pet> GetPetsBySpecies(SpeciesEnum species)
        {
            return _pets.Where(pet => pet.Species == species).ToList();
        }
    }
}
