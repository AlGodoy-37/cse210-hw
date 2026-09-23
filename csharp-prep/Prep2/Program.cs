using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade?:");
        string input = Console.ReadLine();
        int number = int.Parse(input);

        string letter = "";

         if (number >= 90)
        {
            letter = "A";
        }
        else if (number >= 80)
        {
            letter = "B";
        }
        else if (number >= 70)
        {
            letter = "C";
        }
        else if (number >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");
        
        if (number >= 70)
        {
            Console.WriteLine("Congratulations!");
        }
        else
        {
            Console.WriteLine("We encourage you to check the past practice exams and keep studying! Good Luck!");
        }



    }
}