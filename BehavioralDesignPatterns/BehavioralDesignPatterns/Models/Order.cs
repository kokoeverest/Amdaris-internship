using BehavioralDesignPatterns.Interfaces;

namespace BehavioralDesignPatterns.Models
{
    public class Order(IShop shop, IProduct product, IUser customer) : IOrder
    {
        private static int _id;
        public int Id { get; set; } = ++_id;
        public StatusEnum Status { get; set; } = StatusEnum.Pending;
        public IProduct Product { get; set; } = product;
        public IShop Shop { get; set; } = shop;
        public IUser Customer { get; set; } = customer;
    }


    public enum StatusEnum
    {
        Pending, Shipped
    }
}
