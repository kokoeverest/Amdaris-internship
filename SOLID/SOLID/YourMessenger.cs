namespace SOLID
{
    public class YourMessenger : IMessenger
    {
        public List<User> Users { get; set; } = [];

        public void SendMessage(User sender, List<User> receivers, IMessage message)
        {
            if (!Users.Contains(sender))
            {
                throw new InvalidDataException("Sender is not registered!");
            }

            List<User> real_receivers = [];

            foreach (var receiver in receivers)
            {
                if (Users.Contains(receiver))
                {
                    real_receivers.Add(receiver);
                }
                else
                {
                    real_receivers.Add(new User("unknown"));
                }
            }

            Console.WriteLine($"New {message}    from: {sender}\n    to: {string.Join(", ", real_receivers)}\n    [{message.Body}]\n");
        }
    }
}
