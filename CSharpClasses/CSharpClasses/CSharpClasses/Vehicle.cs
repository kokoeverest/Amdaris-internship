using System.Reflection;

namespace CSharpClasses
{
    public interface IVehicle
    {
        void GoLeft() { }
        void GoRight() { }
        void GoStraight() { }
        void GoBack() { }
        void Stop() { }
    }
    public abstract class Vehicle : IVehicle
    {
        private int _left = 0;
        private int _right = 0;
        private int _currentSpeed = 0;
        private int _forward = 0;
        private int _back = 0;
        private int _totalDistance = 0;
        private int speed;
        internal readonly string brand;
        internal readonly string model;
        internal readonly int year;

        internal int MaxSpeed { get => speed;  set => speed = value; }

        public Vehicle() { }
        public Vehicle(string brand, string model, int year, int speed)
        {
            this.brand = brand;
            this.model = model;
            this.year = year;
            this.speed = speed;
        }

        public string CurrentSpeed => $"Current speed: {_currentSpeed }";

        public string Coordinates => $"{brand} {model} is at: {_left} left, {_right} right";
        public string TotalDistance => $"Distance travelled: {_totalDistance} metres";
        public string TripReport
        {
            get
            {
                return $"{brand} {model}, produced in {year}, travelled a total of {_totalDistance / 1000} km; " +
                    $"forward {_forward / 1000} km; backwards {_back / 1000} km";
            }
        }

        public virtual void GoStraight(int speed, int time)
        {
            int result = speed * time;
            _forward += result;
            _totalDistance += result;
            _currentSpeed = speed / 2;
        }
        public virtual void GoBack(int speed, int time)
        {
            int result = speed * time;
            _back += result;
            _totalDistance += result;
        }
        public virtual void Stop()
        {
            _currentSpeed = 0;
        }

        public virtual void GoLeft()
        {
            _left++;
            _right--;
        }
        public virtual void GoRight()
        {
            _right++;
            _left--;
        }
        public virtual void ShowCurrentSpeed()
        {
            Console.WriteLine($"Travelling at {_currentSpeed}");
        }

    }

}
