using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            Console.WriteLine();
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine("Date,Prompt,Response");

            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToCsvLine());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);

        // Replace whatever is in the journal right now
        _entries.Clear();

        // Start at 1 to skip the header line
        for (int i = 1; i < lines.Length; i++)
        {
            if (lines[i].Trim() != "")
            {
                _entries.Add(Entry.FromCsvLine(lines[i]));
            }
        }
    }
}