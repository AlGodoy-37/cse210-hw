using System;
using System.Collections.Generic;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;

    public Entry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine(_response);
        Console.WriteLine();
    }

    // Turns the entry into one CSV line, so Excel can open the file
    public string ToCsvLine()
    {
        return $"{Quote(_date)},{Quote(_prompt)},{Quote(_response)}";
    }

    // Builds an entry back from a CSV line
    public static Entry FromCsvLine(string line)
    {
        List<string> parts = SplitCsvLine(line);
        return new Entry(parts[0], parts[1], parts[2]);
    }

    // Wraps text in quotes and doubles any quotes inside it
    private static string Quote(string text)
    {
        return "\"" + text.Replace("\"", "\"\"") + "\"";
    }

    // Splits a CSV line while handling commas and quotes inside the text
    private static List<string> SplitCsvLine(string line)
    {
        List<string> fields = new List<string>();
        string current = "";
        bool inQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (inQuotes)
            {
                if (c == '"')
                {
                    // Two quotes in a row means one real quote character
                    if (i + 1 < line.Length && line[i + 1] == '"')
                    {
                        current += '"';
                        i++;
                    }
                    else
                    {
                        inQuotes = false;
                    }
                }
                else
                {
                    current += c;
                }
            }
            else
            {
                if (c == '"')
                {
                    inQuotes = true;
                }
                else if (c == ',')
                {
                    fields.Add(current);
                    current = "";
                }
                else
                {
                    current += c;
                }
            }
        }

        fields.Add(current);
        return fields;
    }
}