namespace SOLID
{
    public class YourMessenger
    {
        public List<User> Users { get; set; } = [];

        public void RegisterUser(User user)
        {
            if (!Users.Contains(user)) 
            { 
                Users.Add(user);
                Console.WriteLine($"{user.Name} added to YourMessenger.\n");
            }
            else
            {
                Console.WriteLine($"{user.Name} already added.\n");
            }
        }
        public void SendMessage(User sender, List<User> receivers, IMessage message)
        {
            List<User> real_receivers = [];

            foreach (var receiver in receivers)
            {
                if (Users.Contains(receiver))
                {
                    real_receivers.Add(receiver);
                }
            }

            Console.WriteLine($"New {message}    from: {sender}\n    to: {string.Join(", ", real_receivers)}\n    [{message.Body}]\n");
        }
    }
}
