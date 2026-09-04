using System;

class Program
{
    static void Main(string[] args)
    {

        int number = -1;

        int guess = -1;

        Console.Write("What is the magic number? ");
        number = int.Parse(Console.ReadLine());
        
        while (guess != number)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < number)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > number)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}