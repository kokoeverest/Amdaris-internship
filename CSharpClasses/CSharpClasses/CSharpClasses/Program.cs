
using CSharpClasses;

string honda = "Honda";
string crv = "CR-V";
int hondaYear = 2021;
int hondaSpeed = 200;

string suzuki = "Suzuki";
string suzukivStrom = "V-Strom";
int suzukiYear = 2008;
int suzukiSpeed = 240;

string man = "Man";
string manModel = "model";
int manModelYear = 2022;
int manSpeed = 100;

// Creating the objects using named arguments in the constructor
Car carHonda = new(brand: honda, model: crv, year: hondaYear, speed: hondaSpeed);
Motorcycle vStrom = new(brand: suzuki, model: suzukivStrom, year: suzukiYear, speed: suzukiSpeed);
Truck manTruck = new(brand: man, model: manModel, year: manModelYear, speed: manSpeed);

carHonda.GoLeft();
carHonda.GoLeft();
carHonda.GoStraight(100, 2);
 
Console.WriteLine(carHonda.Coordinates);
Console.WriteLine(carHonda.TripReport);

vStrom.GoLeft();

Console.WriteLine(vStrom.Coordinates);

vStrom.GoRight();
vStrom.GoBack(5, 2);

Console.WriteLine(manTruck.MaxSpeed);
Console.WriteLine(vStrom.TripReport);
Console.WriteLine(vStrom.CurrentSpeed);

// is and as operators examples
var vehicle = new Car();
object car = new Truck(brand: "random brand", model: "random model", year: 9999, speed: 0);

if (vehicle.brand is not null && vehicle.model is not null)
{
    Console.WriteLine(vehicle.TripReport);
}
else
{
    // watch the video one more time for this
    var newVehicle = car as Vehicle;
    if (newVehicle is not null)
    {
        Console.WriteLine(newVehicle);
        Console.WriteLine(newVehicle.TripReport);
    }
    else
    {
        Console.WriteLine("Nothing to write");
    }
}

// playing with the IEnumerable implementation
Vehicle[] garage =
[
carHonda,
vStrom,
manTruck,
];

Garage newGarage = new(garage);
var enumGarage = newGarage.GetEnumerator();

while (enumGarage.MoveNext())
    Console.WriteLine(enumGarage.Current.MaxSpeed);

// invoking the custom property LastObject
enumGarage.LastObject?.GoStraight(200, 20);

// testing the custom Add and Resize methods in the Garage IEnumerator class
enumGarage.Add(car);

Console.WriteLine(enumGarage.LastObject?.Coordinates);
