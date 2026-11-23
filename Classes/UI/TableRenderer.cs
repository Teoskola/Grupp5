using Spectre.Console;

namespace Grupp5;

public static class TableRenderer
{
    //METODER

    // ShowRestaurants(list): void - visar en lista av restauranger i tabellformat(Id, namn, kök, betyg...)
    // Bygger och skriver ut en tabell för en lista restauranger
    public static void ShowRestaurantTable(List<Restaurant> list)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Namn");
        table.AddColumn("Kök");
        table.AddColumn("Område");
        table.AddColumn("Adress");
        table.AddColumn("Betyg");

        foreach (var restaurant in list)
        {
            table.AddRow(
                restaurant.Id.ToString(),
                Markup.Escape(restaurant.Name ?? ""),
                restaurant.Cuisinetype.ToString(),
                Markup.Escape(restaurant.District ?? ""),
                Markup.Escape(restaurant.Address ?? ""),
                restaurant.Rating.ToString("0.0"));
        }

        AnsiConsole.Write(table);
    }

    // ShowStatistics(stats): void - visar statistik som tabell/diagram
    public static void ShowStatistics(StatisticsService stats)
    {
        var counts = stats.CountByCuisine();

        if (counts.Count == 0)
        {
            ConsoleHelper.ShowError("Listan är tom, det finns ingen statistik att visa.");
            return;
        }

        // Tabell med antal restauranger per kök
        var table = new Table();
        table.AddColumn("Kök");
        table.AddColumn("Antal restauranger");

        foreach (var stat in counts)
        {
            table.AddRow(stat.Key.ToString(), stat.Value.ToString());
        }
        AnsiConsole.Write(table);

        // Topp 3 högst betygsatta restauranger
        AnsiConsole.MarkupLine("\n[green]Topp 3 högst betyg:[/]");
        ShowRestaurantTable(stats.GetTopRated(3));
    }
}