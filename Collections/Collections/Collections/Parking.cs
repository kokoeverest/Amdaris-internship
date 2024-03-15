namespace Collections
{
    public class Parking
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<Customer> _customerRepository;
        private int _capacity;

        public Parking(IRepository<Car> carRepository, IRepository<Customer> customerRepository, int capacity)
        {
            _carRepository = carRepository;
            _customerRepository = customerRepository;
            _capacity = capacity;
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
    
            if (HasCapacity == false)
            {
                Console.WriteLine("Parking has no capacity!");
                return false;
            }

            _capacity--;
            _carRepository.Add(car);
            customer.hasPaid = false;
            Console.WriteLine($"Customer {customer.Name} parked {car.RegPlate}.");
            return true;
        }

        public bool Exit(int customerId, int carId)
        {
            List<Entity> result = Validate(customerId, carId);

            if (result.Count < 2)
            {
                return false;
            }

            var customer = result[0] as Customer;
            var car = result[1] as Car;

            if (customer.hasPaid == false)
            {
                Console.WriteLine($"Customer {customer.Name} has to pay first!");
                Thread.Sleep(2000);
                Pay(customer);
            }
        
            _capacity++;
            _carRepository.Delete(car);
            Console.WriteLine($"Customer {customer.Name} left with {car.RegPlate}.");
            return true;
        }

        public List<Entity> Validate(int customerId, int carId)
        {
            List<Entity> result = new ();
            Customer customer = _customerRepository.GetById(customerId);
            
            if (customer == null)
            {
                Console.WriteLine($"Customer {customerId} not found.");
            }
            else
            {
                result.Add(customer);
            }

            Car car = _carRepository.GetById(carId);

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
        public bool HasCapacity => _capacity > 0;

        public int Capacity => _capacity;
    }
}
