namespace SOLID
{
    public class User(string name) : IUser
    {
        public string Name { get; set; } = name;
    }
}
