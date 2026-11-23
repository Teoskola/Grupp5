namespace Grupp5;
using System.Text.Json;

public class LogService
{
    //ATTRIBUTER
    // logFile: string = "log.json" - filens namn
    private string logFile = "log.json";
    // entries: List<LogEntry> - alla loggposter
    private List<LogEntry> entries = new List<LogEntry>();

    //METODER
    // LogEvent(message): void - loggar en vanlig händelse
    public LogService()
    {
        try
        {
            if (File.Exists(logFile))
            {
                string json = File.ReadAllText(logFile);
                entries = JsonSerializer.Deserialize<List<LogEntry>>(json) ?? new List<LogEntry>();
            }
        }
        catch (JsonException)
        {
            entries = new List<LogEntry>();   // trasig/tom fil -> börja om
        }
    }
    public void LogEvent(string message)
    {
        // Skapar en ny loggpost och lägger till den i listan
        var entry = new LogEntry
        {
            // Exakt tidpunkt för loggningen utan att man själv behöver skriva in den
            Timestamp = DateTime.Now,
            // Nivån är "info" för vanliga händelser
            Level = "Info",
            // Meddelandet är det som skickades in som parameter
            Message = message
        };
        entries.Add(entry);
        SaveLog(); // Spara loggen till filen varje gång en ny post läggs till
    }

    // LogError(message): void - loggar ett fel med exception-text
    public void LogError(string message, Exception ex)
    {
        var entry = new LogEntry
        {
            Timestamp = DateTime.Now,
            // Nivån är "error" för fel
            Level = "Error",
            // Meddelandet är det som skickades in som parameter + exception-texten
            Message = message + " - Exception: " + ex.Message
        };
        entries.Add(entry);
        SaveLog(); // Spara loggen till filen varje gång en ny post läggs till
    }
    
    // SaveLog(): void - skriver listan till log.json
    public void SaveLog()
    {
        // Serialiserar listan till JSON och sparar i filen
        try
        {
            string json = JsonSerializer.Serialize(entries, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(logFile, json);
        }
        catch (Exception ex)
        {
            ConsoleHelper.ShowError($"Kunde inte spara log till JSON: {ex.Message}");
        }
    }
}