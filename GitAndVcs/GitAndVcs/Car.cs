using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GitAndVcs
{
    class Car
    {
        string brand = string.Empty;
        string model = string.Empty;
        public Car(string brandName, string modelName)
        {
            brand = brandName;
            model = modelName;
        }
    static void Main(string[] args)
    {
        Car car = new Car("Ford", "Mustang");
        Console.WriteLine(car.model);
    }
    }
}

