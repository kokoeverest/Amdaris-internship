namespace PetShop
{
    public interface IPetsRepository
    {
        Pet Create(Pet pet);
        Pet GetPetById(int id);
        List<Pet> GetAll();
        List<Pet> GetPetsBySex(SexEnum sex);
        List<Pet> GetPetsBySpecies(SpeciesEnum sex);
        int GetLastId();
    }
}
