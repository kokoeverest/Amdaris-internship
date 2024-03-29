using BehavioralDesignPatterns.Interfaces;
using BehavioralDesignPatterns.Models;

namespace BehavioralDesignPatterns.Observers
{
    internal class OrderProcessor
    {
        public async Task<bool> ProcessOrder(IShop shop, IOrder order)
        {
            if (shop.StaffMembers.FirstOrDefault() is not StaffMember staffMember)
            {
                Console.WriteLine("No available worker to do the job");
                return false;
            }
            else
            {
                staffMember.Status = Occupancy.Busy;
                Console.WriteLine($"Order processed by {staffMember.Name}");

                await Task.Delay(2000);
                switch (order.Status)
                {
                    case StatusEnum.Pending:
                        order.Status = StatusEnum.Shipped;
                        break;
                    case StatusEnum.Shipped:
                        break;
                }
                staffMember.Status = Occupancy.Free;
                return true;
            }
        }
    }
}