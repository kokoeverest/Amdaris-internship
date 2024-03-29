using BehavioralDesignPatterns.Interfaces;

namespace BehavioralDesignPatterns.Models
{
    public class Book(string title, string author) : IProduct
    {
        private static int _id;
        public int Id { get; set; } = ++_id;
        public string Title { get; set; } = title;
        public string Author { get; set; } = author;

        public override string ToString() => "Book";
    }
}
