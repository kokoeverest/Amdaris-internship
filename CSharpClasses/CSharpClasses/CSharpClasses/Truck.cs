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
                base.GoBack(base.MaxSpeed, time);
            }
            base.GoBack(speed, time);
        }

        public override void GoStraight(int speed, int time)
        {
            if (speed > MaxSpeed)
            {
                Console.WriteLine($"Max speed is {base.MaxSpeed}");
                base.GoStraight(base.MaxSpeed, time);
            }
            base.GoStraight(speed, time);
        }
        public void GoStraight(string direction)
        {
            if (direction == "left")
            {
                base.GoLeft();
            }
            
            else if (direction == "right")
            {
                base.GoRight();
            }
        }
    }
}
