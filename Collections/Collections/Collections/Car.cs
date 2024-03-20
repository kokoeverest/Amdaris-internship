namespace Collections
{
    public class Car : Entity
    {
        public Car(int Id, string plateNumber)
        {
            this.Id = Id;
            RegPlate = plateNumber;
        }
        public string? RegPlate {  get; set; }
    }
}
