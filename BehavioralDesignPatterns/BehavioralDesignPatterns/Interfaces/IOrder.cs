using BehavioralDesignPatterns.Models;

namespace BehavioralDesignPatterns.Interfaces
{
    public interface IOrder
    {
        private static readonly int _id;
        public int Id { get { return _id; } }
        public StatusEnum Status { get; set; }
        public IProduct Product { get; set; }
        public IShop Shop { get; set; }
        public IUser Customer { get; set; }
    }
}
