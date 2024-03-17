namespace Internship_Project
{
    public class Athlete(
        string name,
        string lastName,
        string email,
        string password,
        string country,
        string phone,
        string birthDate,
        string sport
        ) : IUser
    {
        public int? Id { get; set; } = null;
        public string Name { get; set; } = name;
        public string LastName { get; set; } = lastName;
        public string MiddleName { get; set; } = string.Empty;
        public string Email { get; set; } = email;
        public string Password { private get; set; } = password;
        public string Country { get; set; } = country;
        public string Phone { get; set; } = phone;
        public string BirthDate { get; set; } = birthDate;
        public string Sport { get; set; } = sport;
        public List<IUser> Sponsors { get; set; } = [];

        public void Register(string email, string password) { }
        public void Login() { }
        public void Logout() { }
        public void ResetPassword() { }
        public void EditProfile() { }
    }
}
