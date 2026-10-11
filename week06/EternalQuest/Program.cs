using System;

// I added a rank system that updates the user rank based on their points whenever the score changes.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}