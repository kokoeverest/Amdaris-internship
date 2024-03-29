using BehavioralDesignPatterns.Interfaces;

namespace BehavioralDesignPatterns.Models
{
    public class Email(string text) : Message(text), IMessage
    {
        public override string ToString() => "Email";
    }
}
