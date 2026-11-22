namespace Grupp5;
using Spectre.Console;

public class ConsoleHelper
{
    //METODER
    // ShowTitle(): void - rubrik som visas överst i menyn (ingen animation)
    public static void ShowBanner()
    {
        AnsiConsole.Write(new Rule("[blue]Välkommen till[/]").RuleStyle("grey").Centered());
        AnsiConsole.Write(new FigletText("Restaurangguiden").Centered().Color(Color.Blue));
        AnsiConsole.Write(
            new Panel(Align.Center(new Markup("[italic]Alla dina matställen, samlade på ett ställe[/]")))
                .Border(BoxBorder.Rounded)
                .BorderColor(Color.Grey));
        AnsiConsole.WriteLine();
    }
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
    public static void ShowSpinner(string text, Action work)
    {
        AnsiConsole.Status()
            .Spinner(Spinner.Known.Dots)
            .Start(text, ctx =>
        {
            work();
            Thread.Sleep(1500); // Simulera en kort fördröjning för att visa snurran
        });
    }

    //ShowProgressBar(text, work): void - progress bar medan något laddas/sparas
    public static void ShowProgress(string text)
    {
        AnsiConsole.Progress()
            .Start(ctx =>
            {
                var task = ctx.AddTask(text);

                while (!ctx.IsFinished)
                {
                    task.Increment(5);
                    Thread.Sleep(50);
                }
            });
    }
}