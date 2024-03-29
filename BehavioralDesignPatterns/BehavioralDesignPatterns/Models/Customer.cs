using System.Text;
using BehavioralDesignPatterns.Interfaces;

namespace BehavioralDesignPatterns.Models
{
    public class Customer(string name, string? email, string? phoneNumber) : User(name, email, phoneNumber)
    {

        public List<IOrder> Orders { get; set; } = [];

        public void BuyProduct(IShop shop, IProduct product)
        {
            var order = shop.SellProduct(this, product);

            if (order is not null)
            {
                Orders.Add(order);
            }
            else
            {
                Console.WriteLine("Couldn't place order");
            }
        }
    }
}
