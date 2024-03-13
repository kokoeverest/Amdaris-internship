namespace CSharpClasses
{
    internal class Truck : Vehicle
    {
        private new readonly int MaxSpeed;
        public Truck() { }
        public Truck(string brand, string model, int year, int speed) : base(brand, model, year, speed)
        {
            if (speed > MaxSpeed)
            {
                base.MaxSpeed = 89;
            }
            else if (speed > 0)
            {
                base.MaxSpeed = speed;
            }
        }

        public override void GoBack(int speed, int time)
        {
            if (speed > MaxSpeed)
            {
                Console.WriteLine($"Max speed is {base.MaxSpeed}");
                base.GoBack(MaxSpeed, time);
            }
            base.GoBack(speed, time);
        }

        public override void GoStraight(int speed, int time)
        {
            if (speed > MaxSpeed)
            {
                Console.WriteLine($"Max speed is {base.MaxSpeed}");
                base.GoStraight(MaxSpeed, time);
            }
            base.GoStraight(speed, time);
        }
    }
}
