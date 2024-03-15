namespace Collections
{
    public class Parking
    {
        private readonly IRepository<Car> _registeredCars;
        private readonly List<Car> _parkedCars;
        private readonly IRepository<Customer> _registeredUsers;
        private int _freeParkingSpace;
        private int _capacity;

        public Parking(IRepository<Car> carRepository, IRepository<Customer> customerRepository, int capacity)
        {
            _registeredCars = carRepository;
            _registeredUsers = customerRepository;
            _freeParkingSpace = capacity;
            _capacity = capacity;
            _parkedCars = [];
        }
        public bool Enter(int customerId,  int carId)
        {
            List<Entity> result = Validate(customerId, carId);
            if (result.Count < 2)
            {
                return false;
            }
            
            var customer = result[0] as Customer;
            var car = result[1] as Car;
            if (_parkedCars.Contains(car))
            {
                Console.WriteLine($"Car {car.RegPlate} is already parked here!");
                return false;
            }
            if (HasCapacity == false)
            {
                Console.WriteLine("Parking has no capacity!");
                return false;
            }

            _freeParkingSpace--;
            _parkedCars.Add(car);
            customer.hasPaid = false;
            Console.WriteLine($"Customer {customer.Name} parked {car.RegPlate}.");
            return true;
        }

        public bool Exit(int customerId, int carId)
        {
            if (_freeParkingSpace.Equals(_capacity))
            {
                Console.WriteLine("Parking is empty, no car to remove!");
                return false;
            }

            List<Entity> result = Validate(customerId, carId);

            if (result.Count < 2)
            {
                return false;
            }

            var customer = result[0] as Customer;
            var car = result[1] as Car;
            if (_parkedCars.Contains(car) == false)
            {
                Console.WriteLine("This car is not found in the parking!");
                return false;
            }

            if (customer.hasPaid == false)
            {
                Console.WriteLine($"Customer {customer.Name} has to pay first!");
                Thread.Sleep(2000);
                Pay(customer);
            }
        
            _freeParkingSpace++;
            _parkedCars.Remove(car);
            Console.WriteLine($"Customer {customer.Name} left with {car.RegPlate}.");
            return true;
        }

        public List<Entity> Validate(int customerId, int carId)
        {
            List<Entity> result = new ();
            Customer customer = _registeredUsers.GetById(customerId);
            
            if (customer == null)
            {
                Console.WriteLine($"Customer {customerId} not found.");
            }
            else
            {
                result.Add(customer);
            }

            Car car = _registeredCars.GetById(carId);

            if (car == null)
            {
                Console.WriteLine($"Car {carId} not found.");
            }
            else
            {
                result.Add(car);
            }

            return result;
        }
        public void Pay(Customer customer)
        {
            Console.WriteLine($"Customer {customer.Name} paid successfully\n");
            customer.hasPaid = true;
        }
        public bool HasCapacity => _freeParkingSpace > 0;

        public string FreeSpots => $"Parking has {_freeParkingSpace} free spots";
        public string Capacity => $"Parking has {_capacity } places";
        public void ShowCars()
        {
            foreach (Car car in _parkedCars)
                Console.WriteLine($"Car: {car.RegPlate}");
        }
    }
}
