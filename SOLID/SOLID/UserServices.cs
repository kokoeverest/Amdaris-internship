namespace SOLID
{
    public class UserServices
    {
        public void RegisterUser(User user, IMessenger messenger)
        {
            if (!messenger.Users.Contains(user))
            {
                messenger.Users.Add(user);
                Console.WriteLine($"{user.Name} added to YourMessenger.\n");
            }
            else
            {
                Console.WriteLine($"{user.Name} already added.\n");
            }
        }
    }
}
