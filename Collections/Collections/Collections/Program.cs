using Collections;

IRepository<Car> carRepo = new ListRepository<Car>();
IRepository<Customer> customerRepo = new ListRepository<Customer>();

Car car1 = new(Id: 11, plateNumber: "CA 1234 KK");
Car car2 = new(Id: 22, plateNumber: "X 9999 MM");
Customer customer1 = new(Id: 1, Name: "Petar Ivanov");
Customer customer2 = new(Id: 2, Name: "Ivan Petrov");

customer1.Cars?.Add(car1);
customer2.Cars?.Add(car2);
carRepo.Add(car1);
carRepo.Add(car2);
customerRepo.Add(customer1);
customerRepo.Add(customer2);


Parking parking = new Parking(carRepo, customerRepo, 2);

parking.Enter(1, 11);
parking.Enter(2, 22);
Console.WriteLine(parking.FreeSpots);
parking.ShowCars();
parking.Exit(1, 11);
parking.Exit(2, 22);
parking.Exit(2, 22);
Console.WriteLine(parking.FreeSpots);
parking.Enter(1, 11);
parking.Enter(1, 11);