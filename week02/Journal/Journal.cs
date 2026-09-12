using System.Globalization;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
            
        }
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();

        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            string date = parts[0];
            string prompt = parts[1];
            string entry = parts[2];

            Entry newEntry = new Entry(date, prompt, entry);
            AddEntry(newEntry);
        }
    }

    public void ShowStatistics()
    {
        int totalWords = 0;
        int totalEntries = _entries.Count();

        Console.WriteLine($"Total Entries: {totalEntries}");
        foreach (Entry entry in _entries)
        {
            string[] words = entry._entryText.Split(' ');
            totalWords += words.Length;
        }
        Console.WriteLine($"Total Words: {totalWords}");
    }
}