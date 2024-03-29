using BehavioralDesignPatterns.Interfaces;

namespace BehavioralDesignPatterns.Models
{
    public class Sms(string text) : Message(text), IMessage
    {
        public override string ToString() => "SMS";
    }
}
