using BehavioralDesignPatterns.Interfaces;

namespace BehavioralDesignPatterns.Models
{
    public abstract class User(string name, string? email, string? phoneNumber) : IUser
    {
        private static int _id;
        public int Id { get; set; } = ++_id;
        public string Name { get; set; } = name;
        public string? Email { get; set; } = email;
        public string? PhoneNumber { get; set; } = phoneNumber;

        public void ReceiveMessage(IMessage message)
        {
            Console.WriteLine($"{message}: {message.Text}");
        }
    }
}
