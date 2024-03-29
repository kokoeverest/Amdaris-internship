using BehavioralDesignPatterns.Models;
using BehavioralDesignPatterns.Observers;

namespace BehavioralDesignPatterns.Interfaces
{
    public interface IShop
    {
        public List<IProduct> Books { get; set; }
        public List<IUser> Subscribers { get; set; }
        public List<IUser> StaffMembers { get; set; }
        public List<IOrder> Orders { get; set; } 
        public INotification Notifications { get; set; }
        public IOrder? SellProduct(IUser customer, IProduct product);
    }
}