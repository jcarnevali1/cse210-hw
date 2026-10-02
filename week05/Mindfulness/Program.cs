using System;

// I added a feature so the program tracks how many activities the user completes in the session and shows the total when the user quits the program. If the user didn't complete any activities, it only shows the goodbye message.

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;
        int activityCount = 0;

        while(choice != 4)
        {
            Console.Clear();

            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Start breathing activity");
            Console.WriteLine(" 2. Start reflecting activity");
            Console.WriteLine(" 3. Start listing activity");
            Console.WriteLine(" 4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = int.Parse(Console.ReadLine());

            if(choice == 1)
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                activityCount++;
            }
            else if(choice == 2)
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                activityCount++;
            }
            else if(choice == 3)
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                activityCount++;
            }
            else if(choice == 4)
            {
                Console.Clear();
                if(activityCount > 0)
                {
                    Console.WriteLine($"You completed {activityCount} mindfulness activities this session!");
                }
                Console.WriteLine("Have a great day.");
            }
        }
    }
}