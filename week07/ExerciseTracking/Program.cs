using System;

class Program
{
    static void Main(string[] args)
    {
        DateTime time = new DateTime(2022, 11, 3);

        Running running = new Running(time, 45, 8);
        Cycling cycling = new Cycling(time, 60, 25);
        Swimming swimming = new Swimming(time, 40, 50);
        List<Activity> activities = new List<Activity>();
        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}