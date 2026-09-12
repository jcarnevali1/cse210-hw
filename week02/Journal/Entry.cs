public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry(string dateText, string promptText, string entryText)
    {
        _date = dateText;
        _promptText = promptText;
        _entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine(_entryText);
        Console.WriteLine("");
    }
}