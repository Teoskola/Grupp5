namespace Grupp5;

class Program
{
    static void Main(string[] args)
    {
        ConsoleHelper.ShowProgress("Startar...");
        var restaurantService = new RestaurantService();
        // Ladda restauranger från JSON-fil (om filen finns)
        restaurantService.Load();

        var mainMenu = new MainMenu(restaurantService);
        mainMenu.Run();

        // Spara restauranger till JSON-fil innan programmet avslutas
        ConsoleHelper.ShowSpinner("Sparar...", () => restaurantService.Save());
    }
}
