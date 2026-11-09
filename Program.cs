namespace Grupp5;

class Program
{
    static void Main(string[] args)
    {
        var restaurantService = new RestaurantService();
        var mainMenu = new MainMenu(restaurantService);
        mainMenu.Run();
    }
}
