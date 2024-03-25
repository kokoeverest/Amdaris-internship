namespace SOLID
{
    public class EmailMessage(string body, string subject = "No subject") : IMessage
    {
        public string Body { get; set; } = body;
        public string Subject { get; set; } = subject;

        public override string ToString()
        {
            return $"Email\n    subject: [{Subject}]\n";
        }
    }
}
