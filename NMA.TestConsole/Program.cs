using System;

namespace NMALib.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
        
            while (true)
            {
                Console.WriteLine("Please Enter a Title for the Msg or exit:");
                var title = Console.ReadLine();
                if (title == "exit")
                {
                    break;
                }
                Console.WriteLine("\nPlease Enter a Body of the Message");
                var body = Console.ReadLine();
                var fullMsg = "\nYou title is: " + title + "\nWith a body of: " + body;
                Console.WriteLine(fullMsg);


                var notificationMsg =
               new NMANotification
               {
                   Description = body,
                   Event = title,
                   Priority = NMANotificationPriority.Normal
               };

                var messageClient = new NMAClient();
                // Post the notification.
                messageClient.PostNotification(notificationMsg);
            }
        }
    }
}
