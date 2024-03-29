using BehavioralDesignPatterns.Models;

namespace BehavioralDesignPatterns.Interfaces
{
    public interface IOrder
    {
        private static int _id;
        public int Id { get; set; }
        public StatusEnum Status { get; set; }
        public IProduct Product { get; set; }
        public IShop Shop { get; set; }
        public IUser Customer { get; set; }
    }
}
