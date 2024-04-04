using System.Text;

namespace PetShop
{
    public class PetDto
    {
        public AnimalTypeEnum AnimalType { get; set; }
        public string Speciality { get; set; } = string.Empty;
        public int PetId { get; set; }
        public SpeciesEnum Species { get; set; }
        public SexEnum Sex { get; set; }
        public decimal Price { get; set; }

        public static PetDto FromPet(Pet pet)
        {
            return new PetDto
            {
                AnimalType = pet.AnimalType,
                PetId = pet.Id,
                Species = pet.Species,
                Sex = pet.Sex,
                Price = pet.Price,
                Speciality = pet.Speciality
            };
        }

        public override string ToString()
        {
            string template = "{0, 15} {1, -20}";
            StringBuilder returnString = new ();

            returnString.AppendLine(string.Format(template, "Pet Id: ", this.PetId));
            returnString.AppendLine(string.Format(template, "Pet type: ", this.AnimalType));
            returnString.AppendLine(string.Format(template, "Species: ", this.Species));
            returnString.AppendLine(string.Format(template, "Sex: ", this.Sex));
            returnString.AppendLine(string.Format(template, "Price: ", this.Price));
            returnString.AppendLine(string.Format(template, "Speciality: ", this.Speciality));
            
            return returnString.ToString();
        }
    }
}
