namespace SOLID
{
    public class PushMessage(string body) : IMessage
    {
        public string Body { get; set; } = body;
        public override string ToString()
        {
            return "Push message\n";
        }
    }
}
