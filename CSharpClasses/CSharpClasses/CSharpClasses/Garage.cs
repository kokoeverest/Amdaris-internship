using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace CSharpClasses
{
    internal class Garage : IEnumerable
    {
        private Vehicle[] _vehicles;
        public Garage(Vehicle[] vehiclesArray)
        {
            _vehicles = new Vehicle[vehiclesArray.Length];
            for (int i = 0; i < vehiclesArray.Length; i++)
                _vehicles[i] = vehiclesArray[i];
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }
        public GarageEnum GetEnumerator()
        {
            return new GarageEnum(_vehicles);
        }
    }
    public class GarageEnum : IEnumerator
    {
        public Vehicle[] _vehicles;
        int position = -1;
        public GarageEnum(Vehicle[] vArray) => _vehicles = vArray;

        public bool MoveNext()
        {
            position++;
            return (position < _vehicles.Length);
        }
        public bool MovePrevious()
        {
            position--;
            return (position >= 0);
        }
        public void Reset()
        {
            position = -1;
        }
        public void Add(object element)
        {
            if (IsFull())
            {
                Resize();
            }
            _vehicles.Append(element);
        }
        public bool IsFull()
        {
            // is this syntax better than _vehicles[_vehicles.Length - 1] 
            return _vehicles[^1] is not null;
        }
        public void Resize()
        {
            Console.WriteLine("Resizing garage");
            Vehicle[] newArray =  new Vehicle[_vehicles.Length * 2];
            for (int i = 0; i < _vehicles.Length; i++)
                newArray[i] = _vehicles[i];
            _vehicles = newArray;
        }
        public Vehicle? LastObject
        {
            get
            {
                if (IsFull())
                {
                    return _vehicles[_vehicles.Length - 1];
                }
                else
                {
                    for (int i = _vehicles.Length - 1; i >= 0; i--)
                        if (_vehicles[i] is not null)
                        {
                            return _vehicles[i];
                        }
                }
                return null;
            }
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public Vehicle Current
        {
            get
            {
                try
                {
                    return _vehicles[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
