namespace InversionOfControl
{
    public interface IUser
    {
        int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
