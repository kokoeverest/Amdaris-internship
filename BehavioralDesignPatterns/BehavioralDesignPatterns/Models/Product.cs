using BehavioralDesignPatterns.Interfaces;

namespace BehavioralDesignPatterns.Models
{
    public abstract class Product : IProduct
    {
        private static int _id;
        public int Id { get; set; } = ++_id;
    }
}
