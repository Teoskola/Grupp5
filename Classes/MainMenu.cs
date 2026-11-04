namespace Grupp5;

public class MainMenu
{
    //ATTRIBUTER
    // restaurants: RestaurantService - används för CRUD och sökning
    // stats: StatisticsService - används för statistikvyn

    //METODER
    //Run(): void - loop som visar menyn tills användaren väljer "Avsluta"
    // HandleChoice(choice: string): void - switch/case som skickar vidare till rätt metod
    // AddRestaurant(): void - frågar efter data, validerar, skapar Restaurant
    // EditRestaurant(): void - väljer restaurang och ändrar fält
    // DeleteRestaurant(): void - tar bort resturang efter bekräftelse
    // SearchRestaurants(): void - frågar efter söktext/filter och visar resultat
}