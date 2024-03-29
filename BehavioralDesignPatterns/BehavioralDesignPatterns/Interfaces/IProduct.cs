namespace BehavioralDesignPatterns.Interfaces
{
    public interface IProduct
    {
        private static readonly int _id;
        public int Id { get { return _id; } }
    }
}