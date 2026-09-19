using System;

// I selected some of my favorite scriptures and added the function so that the program randomly selects one of the scriptures to present to the user.
class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>();

        scriptures.Add(new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " + "In all thy ways acknowledge him, and he shall direct thy paths."));
        scriptures.Add(new Scripture(new Reference("John", 10, 14, 15), "I am the good shepherd, and know my sheep, and am known of mine. " + "As the Father knoweth me, even so know I the Father: and I lay down my life for the sheep."));
        scriptures.Add(new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me."));
        scriptures.Add(new Scripture(new Reference("1 Nephi", 3, 7), "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."));

        Random randomGenerator = new Random();
        int index = randomGenerator.Next(scriptures.Count);

        Scripture scripture = scriptures[index];

        string input = "";

        while (input != "quit" && scripture.IsCompletelyHidden() == false)
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
            input = Console.ReadLine();

            if (input != "quit")
            {
                scripture.HideRandomWords(3);
            }

        }
        if (scripture.IsCompletelyHidden() == true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}