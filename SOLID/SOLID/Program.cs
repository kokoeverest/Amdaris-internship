//You are tasked with designing and implementing a notification system for a messaging application.
//The system should allow users to send notifications to other users via various channels such as email,
//SMS, and push notifications.

//Your implementation should adhere to SOLID principles, focusing on specific principles relevant
//to the scenario. It should be implemented in a console application.

//The system should support multiple notification channels and be flexible enough to accommodate
//future changes or additions to notification types and channels.

using SOLID;

UserServices service = new();
YourMessenger messenger = new();
User petar = new("Petar");
User mitko = new("Mitko");
User maria = new("Maria");
User ivan = new("Ivan");

service.RegisterUser(petar, messenger);
service.RegisterUser(mitko, messenger);
service.RegisterUser(maria, messenger);
service.RegisterUser(mitko, messenger);

List<Tuple<User, List<User>, IMessage>> messages = [

    new Tuple<User, List<User>, IMessage> (mitko, [petar], new EmailMessage(body: "Hey, we haven't seen in a long time, man!", subject: "Highschool meeting")),
    new Tuple<User, List<User>, IMessage> (petar, [mitko], new SmsMessage("We can always use the phone to call each other :)")),
    new Tuple<User, List<User>, IMessage> (mitko, [petar], new PushMessage("I also use YourMessenger to communicate with others. Highly recommended")),
    new Tuple<User, List<User>, IMessage> (petar, [maria, mitko, ivan], new PushMessage("Great!!! I am addding Maria and Ivan to the group chat ;)")),
    new Tuple<User, List<User>, IMessage> (maria, [mitko, petar], new PushMessage("Ivan is not in YourMessenger yet, I'll text him.")),
    new Tuple<User, List<User>, IMessage> (maria, [ivan], new SmsMessage("Hey, can you register to YourMessenger so we can add you to the group chat?")),
    new Tuple<User, List<User>, IMessage> (ivan, [maria], new SmsMessage("No problem!!!")),
    new Tuple<User, List<User>, IMessage> (petar, [maria, mitko, ivan], new PushMessage("I can see Ivan is in the chat now :) Hi Ivo"))
    ];

foreach (Tuple<User, List<User>, IMessage> message in messages)
{
    try
    {
        messenger.SendMessage(message.Item1, message.Item2, message.Item3);

    }
    catch (InvalidDataException exc)
    {
        Console.WriteLine(exc.Message); ;
        service.RegisterUser(ivan, messenger);
    }
    
}

Console.WriteLine("No more messages to send");
