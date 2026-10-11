using System;
using System.IO;

// EXCEEDING REQUIREMENTS:
// - The journal saves and loads as a .csv file that opens in Excel.
//   Every field is wrapped in quotes and quotes inside the text are doubled,
//   so commas and quotation marks in a response don't break the file.
// - The file has a header row (Date,Prompt,Response).
// - Loading a file that doesn't exist shows a message instead of crashing.
// - I added a couple of extra prompts beyond the required five.

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                string date = DateTime.Now.ToShortDateString();
                journal.AddEntry(new Entry(date, prompt, response));
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();

                if (File.Exists(filename))
                {
                    journal.LoadFromFile(filename);
                }
                else
                {
                    Console.WriteLine("That file wasn't found.");
                }
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice != "5")
            {
                Console.WriteLine("Please pick a number from 1 to 5.");
            }
        }
    }
}