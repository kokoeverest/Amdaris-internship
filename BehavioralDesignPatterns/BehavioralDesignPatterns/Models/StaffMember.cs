namespace BehavioralDesignPatterns.Models
{
    public class StaffMember(string name, string? email, string? phoneNumber) : User(name, email, phoneNumber)
    {
        public Occupancy Status { get; set; } = Occupancy.Free;
    }

    public enum Occupancy
    {
        Free, Busy
    }
}
