namespace Grupp5;
using Spectre.Console;

public class ConsoleHelper
{
    //METODER
    // ShowBanner(): void - animerad startskärm / banner
    // ShowSuccess(message): void - grön text
    public static void ShowSuccess(string message)
    {
        AnsiConsole.MarkupLine($"[green]{Markup.Escape(message)}[/]");
    }
    // ShowError(message): void - röd text
    public static void ShowError(string message)
    {
        AnsiConsole.MarkupLine($"[red]{Markup.Escape(message)}[/]");
    }
    // ShowSpinner(text, work): void - snurrar medan något laddas/sparas
}