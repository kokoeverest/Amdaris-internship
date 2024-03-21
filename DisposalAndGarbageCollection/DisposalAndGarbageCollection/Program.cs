using System.Net;
using System.Net.Mail;
using System.ComponentModel;

namespace Examples.SmtpExamples.Async
{
    // Assignment requirements

    // You are tasked with developing a console application for sending email notifications to users.
    // The application should allow users to provide their email address as console input and send
    // them an email thanking them for subscribing to the newsletter. Proper resource management and
    // cleanup are crucial to ensure efficient handling of SMTP connections and prevent memory leaks.
    public class SimpleAsynchronousExample
    {
        static bool mailSent = false;
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
            mailSent = true;
        }
        public static void Main(string[] args)
        {
            // Command-line argument must be the SMTP host.
            using SmtpClient client = new ("smtp.abv.bg", 465);
            client.Timeout = 10000;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            //client.Credentials = CredentialCache.DefaultNetworkCredentials;
            NetworkCredential credential = new(userName: "kokoeverest@abv.bg", password: "");
            client.Credentials = credential;


            MailAddress from = new ("kokoeverest@abv.bg", "Kaloyan " + "Peychev", System.Text.Encoding.UTF8);
            MailAddress to = new ("kokoeverest@gmail.com");

            using MailMessage message = new (from, to);

            message.Subject = "Subscription confirmation";
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            message.Body = "Thank you for subscribing for our news letter!";
            message.BodyEncoding = System.Text.Encoding.UTF8;

            // Set the method that is called back when the send operation ends.
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

            // The userState can be any object that allows your callback
            // method to identify this send operation.
            // For this example, the userToken is a string constant.
            string userState = "test message1";
            try
            {
                //Smtp.Send(message);
                client.Send(message);
            }
            catch (Exception e)
            {
                // timeout exception
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Sending message... press c to cancel mail. Press any other key to exit.");
            string? answer = Console.ReadLine();
            // If the user canceled the send, and mail hasn't been sent yet,
            // then cancel the pending operation.
            if (answer.StartsWith("c") && mailSent == false)
            {
                client.SendAsyncCancel();
                Console.WriteLine("Message cancelled.");
            }
            // Clean up.
            //message.Dispose();
            Console.WriteLine("Goodbye.");
        }
    }
}