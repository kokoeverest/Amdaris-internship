namespace Collections
{
    public class Car : Entity
    {
        public string? RegPlate {  get; set; }

        public Car(int Id, string plateNumber)
        {
            this.Id = Id;
            RegPlate = plateNumber;
        }
    }
}
