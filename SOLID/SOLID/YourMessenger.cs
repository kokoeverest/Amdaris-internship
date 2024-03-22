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
                Console.WriteLine($"{user.Name} added to YourMessenger.");
            }
            else
            {
                Console.WriteLine($"{user.Name} already added.");
            }
        }
        public void SendMessage(IMessage message)
        {
            Console.WriteLine(message);
        }
    }
}
