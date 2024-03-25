namespace SOLID
{
    public class SmsMessage(string body) : IMessage
    {
        public string Body { get; set; } = body;
       
        public override string ToString()
        {
            return "SMS message\n";
            
        }
    }
}
