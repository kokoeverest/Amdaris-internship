namespace Internship_Project
{
    public interface IUser
    {
        public int? Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string Password { set; }
        public string Country { get; }
        public string Phone { get; set; }

        public void Register(string email, string password) { }
        public void Login() { }
        public void Logout() { }
        public void ResetPassword() { }
        public void EditProfile() { }
    }
}
