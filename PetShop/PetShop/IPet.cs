namespace PetShop
{
    public interface IPet
    {
        public AnimalTypeEnum AnimalType { get; set; }
        public SpeciesEnum Species { get; set; }
        public SexEnum Sex { get; set; }
        public decimal Price { get; set; }
        public string Speciality {  get; set; }
    }
}
