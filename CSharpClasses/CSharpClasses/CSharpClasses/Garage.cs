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
            return (position == -1);
        }
        public void Reset()
        {
            position = -1;
        }
        public Vehicle LastObject => _vehicles[_vehicles.Length - 1];
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
