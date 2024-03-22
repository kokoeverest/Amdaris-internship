namespace SOLID
{
    public class EmailMessage(string body, string? subject, User sender, User receiver) : IMessage
    {
        public string Body { get; set; } = body;
        public string? Subject { get; set; } = subject;
        public User Sender { get; set; } = sender;
        public User Receiver { get; set; } = receiver;

        public override string ToString()
        {
            return $"\nNew Email from {Sender.Name} to {Receiver.Name}:\nSubject: [ {Subject} ]\n[    {Body}]";
        }

    }
}
