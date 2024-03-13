namespace CSharpClasses
{
    internal class Motorcycle(string brand, string model, int year, int speed) : Vehicle(brand, model, year, speed)
    {
        private static void Incline()
        {
            Console.WriteLine("Motorcycle inclines while turning");
        }

        public override void GoLeft()
        {
            Incline();
            base.GoLeft();
        }
        public override void GoRight()
        {
            Incline();
            base.GoRight();
        }
        public override void GoBack(int speed, int time)
        {
            Console.WriteLine("Going back manually, no km added to the odometer");
        }
    }
}
