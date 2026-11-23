namespace Grupp5;

class Program
{
    static void Main(string[] args)
    {
        ConsoleHelper.ShowProgress("Startar...");
        var restaurantService = new RestaurantService();

        // Ladda restauranger från JSON-fil (om filen finns)
        if (!restaurantService.Load())
            ConsoleHelper.ShowError("Kunde inte läsa sparad data. Startar med tom lista (se log.json).");

        var mainMenu = new MainMenu(restaurantService);
        mainMenu.Run();

        // Spara restauranger till JSON-fil innan programmet avslutas
        bool saved = false;
        ConsoleHelper.ShowSpinner("Sparar...", () => saved = restaurantService.Save());

        if (!saved)
            ConsoleHelper.ShowError("Kunde inte spara data. Se log.json för detaljer.");
    }
}
