using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {

        List<int> number_list = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number = -1;

        while (number != 0)
        {
            Console.Write("Enter Number: ");
            number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                number_list.Add(number);
            }
        }

        int sum = 0;
        foreach (int num in number_list)
        {
            sum += num;
        }

        float average = ((float)sum) / number_list.Count;

        int max = number_list[0];

        foreach (int num in number_list)
        {
            if (num > max)
            {
                max = num;
            }
        }

        int min = number_list[0];

        foreach (int num in number_list)
        {
            if (num > 0 && num < min)
            {
                min = num;
            }
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is {max}");
        Console.WriteLine($"The smallest positive number is {min}");
    }
}