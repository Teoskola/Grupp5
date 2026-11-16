namespace Grupp5;

public class LogEntry
{
    //ATTRIBUTER
    // Timestamp: DateTime - tidpunkt för loggningen
    public DateTime Timestamp { get; set; }
    // Level: string - "info" eller "error"
    public string Level { get; set; } = "";
    // Message: string - texten som loggas
    public string Message { get; set; } = "";
}