using BehavioralDesignPatterns.Interfaces;

namespace BehavioralDesignPatterns.Models
{
    public class Book(string title, string author) : Product
    {
        public string Title { get; set; } = title;
        public string Author { get; set; } = author;

        public override string ToString() => "Book";
    }
}
