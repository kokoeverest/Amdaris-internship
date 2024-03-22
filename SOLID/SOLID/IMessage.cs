namespace SOLID
{
    public interface IMessage
    {
        public string Body { get; set; }
        public string? Subject { get; set; }
        public User Sender { get; set; }
        public User Receiver { get; set; }
    }
}
