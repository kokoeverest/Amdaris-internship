
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

Car carHonda = new(brand: honda, model: crv, year: hondaYear, speed: hondaSpeed);
Motorcycle vStrom = new(brand: suzuki, model: suzukivStrom, year: suzukiYear, speed: suzukiSpeed);
Truck manTruck = new(brand: man, model: manModel, year: manModelYear);

carHonda.GoLeft();
carHonda.GoLeft();
carHonda.GoStraight(100, 2);
 
Console.WriteLine(carHonda.Coordinates);
Console.WriteLine(carHonda.TripReport);
vStrom.GoLeft();
Console.WriteLine(vStrom.Coordinates);
vStrom.GoRight();
vStrom.GoBack(5, 2);

Console.WriteLine(vStrom.TripReport);
