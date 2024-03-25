//You are tasked with designing and implementing a notification system for a messaging application.
//The system should allow users to send notifications to other users via various channels such as email,
//SMS, and push notifications.

//Your implementation should adhere to SOLID principles, focusing on specific principles relevant
//to the scenario. It should be implemented in a console application.

//The system should support multiple notification channels and be flexible enough to accommodate
//future changes or additions to notification types and channels.

using SOLID;

YourMessenger messenger = new();
User petar = new ("Petar");
User mitko = new("Mitko");
User maria = new("Maria");
User ivan = new("Ivan");

messenger.RegisterUser(petar);
messenger.RegisterUser(mitko);
messenger.RegisterUser(maria);
messenger.RegisterUser(mitko);

messenger.SendMessage(sender: mitko, receivers: [ petar ], new EmailMessage(body: "Hey, we haven't seen in a long time, man!", subject: "Highschool meeting"));

messenger.SendMessage(sender: petar, receivers: [ mitko ], new SmsMessage("We can always use the phone to call each other :)"));

messenger.SendMessage(sender: mitko, receivers: [petar], new PushMessage("I also use YourMessenger to communicate with others. Highly recommended"));
messenger.SendMessage(sender: petar, receivers: [maria, mitko, ivan], new PushMessage("Great!!! I am addding Maria and Ivan to the group chat ;)"));
messenger.SendMessage(sender: maria, receivers: [mitko, petar], new PushMessage("Ivan is not in YorMessenger yet, I'll text him."));


messenger.SendMessage(sender: maria, receivers: [ivan], new SmsMessage("Hey, can you register to YourMessenger so we can add you to the group chat?"));
messenger.SendMessage(sender: ivan, receivers: [maria], new SmsMessage("No problem!!!"));
messenger.RegisterUser(ivan);

messenger.SendMessage(sender: petar, receivers: [maria, mitko, ivan], new PushMessage("I can see Ivan is in the chat now :) Hi Ivo"));
