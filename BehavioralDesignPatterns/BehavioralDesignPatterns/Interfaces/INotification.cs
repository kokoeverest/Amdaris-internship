namespace BehavioralDesignPatterns.Interfaces
{
    public interface INotification
    {

        public void Notify(List<IUser> subscribers, IOrder order, string message);
    }
}
