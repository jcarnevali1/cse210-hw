using System;

// I added a function that shows you the journal statistics such as the total entries and total words in the loaded journal.

class Program
{
    static void Main(string[] args)
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        Journal journal = new Journal();
        Console.WriteLine("Welcome to the Journal Program!");

        int choice = -1;

        while (choice != 6)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Show Statistics");
            Console.WriteLine("6. Quit");

            Console.Write("What would you like to do? ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                
                DateTime date = DateTime.Now;
                string dateText = date.ToShortDateString();

                string promptText = promptGenerator.GetRandomPrompt();
                Console.WriteLine(promptText);
                Console.Write("> ");
                string entryText = Console.ReadLine();

                Entry entry = new Entry(dateText, promptText, entryText);
                journal.AddEntry(entry);
            }

            if (choice == 2)
            {
                journal.DisplayAll();
            }

            if (choice == 3)
            {
                Console.Write("> ");
                string file = Console.ReadLine();
                journal.LoadFromFile(file);
            }

            if (choice == 4)
            {
                Console.Write("> ");
                string file = Console.ReadLine();
                journal.SaveToFile(file);
            }

            if (choice == 5)
            {
                journal.ShowStatistics();
            }
        }
    }
}