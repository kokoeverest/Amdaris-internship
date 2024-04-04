namespace PetShop
{
    public class Pet(AnimalTypeEnum animalType, SpeciesEnum species, SexEnum sex, string speciality, decimal price) : IPet
    {

        public int Id { get; set; }
        public AnimalTypeEnum AnimalType { get; set; } = animalType;
        public SpeciesEnum Species { get; set; } = species;
        public SexEnum Sex { get; set; } = sex;
        public string Speciality { get; set; } = speciality;
        public decimal Price { get; set; } = price;

    }
}
