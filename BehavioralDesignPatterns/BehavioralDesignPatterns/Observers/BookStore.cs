using BehavioralDesignPatterns.Interfaces;
using BehavioralDesignPatterns.Models;
using System.Numerics;

namespace BehavioralDesignPatterns.Observers
{
    public class BookStore : IShop
    {
        public List<IProduct> Books { get; set; } = [];
        public List<IUser> Subscribers { get; set; } = [];
        public List<IUser> StaffMembers { get; set; } = [];
        public List<IOrder> Orders { get; set; } = [];
        public INotification Notifications { get; set; } = new NotificationSystem();
        internal OrderProcessor OrderProcessor { get; set; } = new();

        public void Subscribe(IUser subscriber)
        {
            if (!Subscribers.Contains(subscriber))
            {
                Subscribers.Add(subscriber);
                Console.WriteLine($"{subscriber.Name} subscribed successfully\n");
            }
            else
            {
                Console.WriteLine($"{subscriber.Name} is already subscribed\n");
            }
        }

        public void Unsubscribe(IUser subscriber, bool email, bool phone)
        {
            if (Subscribers.Contains(subscriber))
            {
                if (email) 
                {
                    subscriber.Email = string.Empty;
                    Console.WriteLine($"{subscriber.Name} unsubscribed successfully from email notifications\n");
                }
                if (phone) 
                {
                    subscriber.PhoneNumber = string.Empty;
                    Console.WriteLine($"{subscriber.Name} unsubscribed successfully from phone notifications\n");
                }
                if (email && phone)
                {
                    Subscribers.Remove(subscriber);
                }
            }
            else
            {
                Console.WriteLine($"{subscriber.Name} is not found\n");
            }
        }

        public void AddStaffMember(StaffMember member)
        {
            Subscribe(member);
            StaffMembers.Add(member);
            Console.WriteLine($"Welcome aboard {member.Name} :)\n");
        }

        public void RemoveStaffMember(StaffMember member)
        {
            Unsubscribe(member, true, true);
            StaffMembers.Remove(member);
            Console.WriteLine($"Goodbye {member.Name}");
        }


        public IOrder? SellProduct(IUser customer, IProduct book)
        {
            if (!Books.Contains(book))
            {
                return null;
            }

            Order order = new(this, book, customer);

            string internalMessage = $"[Internal message] Order {order.Id}: {order.Product}[{order.Product.Id}], Status: {order.Status}\n";
            string customerMessage = $"Order {order.Id}: {order.Product}, Status: {order.Status}\n";

            Books.Remove(book);
            Orders.Add(order);
            Subscribe(customer);
            Notifications.Notify(StaffMembers, order, internalMessage);
            Notifications.Notify([order.Customer], order, customerMessage);

            return order;
        }

        public async Task ProccessOrders(List<int> orders)
        {
            foreach (int id in orders)
            {
                var order = GetOrder(id);

                if (order is not null)
                {
                    await OrderProcessor.ProcessOrder(this, order);
                    Notifications.Notify([order.Customer], order, $"Order {order.Id}: {order.Product}, Status: {order.Status}\n");
                }
                else
                {
                    await Console.Out.WriteLineAsync($"Order {id} not found!");
                }
            }
        }

        public void AddBooks(List<Book> books)
        {
            Books.AddRange(books);
        }

        public IOrder? GetOrder(int id)
        {
            return Orders.FirstOrDefault(order => order.Id == id);
        }

    }
}
