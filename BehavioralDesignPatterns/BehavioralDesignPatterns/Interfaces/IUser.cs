namespace BehavioralDesignPatterns.Interfaces
{
    public interface IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public void ReceiveMessage(IMessage message);
        //public void Unsubscribe(IShop shop, bool email, bool phone);
    }
}
