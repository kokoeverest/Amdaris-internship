namespace SOLID
{
    public class PushMessage(string body, User sender, User receiver) : IMessage
    {
        public string Body { get; set; } = body;
        public string? Subject { get; set; } = string.Empty;
        public User Sender { get; set; } = sender;
        public User Receiver { get; set; } = receiver;

        public override string ToString()
        {
            return $"\nNew Push message from {Sender.Name} to {Receiver.Name}:\n[    {Body}]";
        }
    }
}
