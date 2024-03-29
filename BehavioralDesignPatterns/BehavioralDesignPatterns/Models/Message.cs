using BehavioralDesignPatterns.Interfaces;

namespace BehavioralDesignPatterns.Models
{
    public abstract class Message(string text) : IMessage
    {
        public string Text { get; set; } = text;

        public override string ToString() => $"{this}";
    }
}
