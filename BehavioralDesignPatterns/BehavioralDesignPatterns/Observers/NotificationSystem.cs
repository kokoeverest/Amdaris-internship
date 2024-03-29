using BehavioralDesignPatterns.Interfaces;
using BehavioralDesignPatterns.Models;

namespace BehavioralDesignPatterns.Observers
{
    public class NotificationSystem : INotification
    {
        public NotificationSystem() { }

        public void Notify(List<IUser> subscribers, IOrder order, string message)
        {
            foreach (var subscriber in subscribers)
            {
                if (!string.IsNullOrEmpty(subscriber.Email))
                {
                    Email email = new(message);
                    subscriber.ReceiveMessage(email);
                }
                if (!string.IsNullOrEmpty(subscriber.PhoneNumber))
                {
                    Sms sms = new(message);
                    subscriber.ReceiveMessage(sms);
                }
            }
        }
    }
}
