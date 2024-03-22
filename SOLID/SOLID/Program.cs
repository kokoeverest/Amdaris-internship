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

messenger.RegisterUser(petar);
messenger.RegisterUser(mitko);
messenger.RegisterUser(maria);

messenger.SendMessage(new EmailMessage("Hey, we haven't seen in a long time, man!", "Highschool meeting", petar, mitko));
messenger.SendMessage(new SmsMessage("We can always use the phone to call each other :)", mitko, petar));