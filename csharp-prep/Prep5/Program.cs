using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string name = PromptUserName();
        int number = PromptUserNumber();

        int answer = SquareNumber(number);

        int year;
        PromptUserBirthYear(out year);

        DisplayResult(name, answer, year);
        }

        static void DisplayWelcomeMessage()
        {
        Console.WriteLine("Welcome to the program!");
        }

        static string PromptUserName()
        {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
        }

        static int PromptUserNumber()
        {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
        }

        static void PromptUserBirthYear(out int year)
        {
        Console.Write($"Please enter the year you were born: ");
        year = int.Parse(Console.ReadLine());
        }

        static int SquareNumber(int number)
        {
        int answer = number * number;
        return answer;
        }
        static void DisplayResult(string name, int answer, int year)
        {
        Console.WriteLine($"{name}, the square of your number is {answer}.");
        Console.WriteLine($"{name}, you will turn {2025 - year} years old this year.");
        }

}