using System;

class Program
{
    static void Main(string[] args)
    {
        Random RandomNumber = new Random();
        int MagicNumber = RandomNumber.Next(1, 101);
        
        int guess = -10000;

         while (guess != MagicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (MagicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else if (MagicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

        }
    }
}