namespace Grupp5;

public class MainMenu
{
    //ATTRIBUTER
    // restaurants: RestaurantService - används för CRUD och sökning
    // stats: StatisticsService - används för statistikvyn

    //METODER    
    //Run(): void - loop som visar menyn tills användaren väljer "Avsluta"
    public void Run()
    {
        while (true)
        {
            // HandleChoice(choice: string): void - switch/case som skickar vidare till rätt metod
            // Visa meny
            // Läs in val
            // Hantera val
            Console.WriteLine("Välkommen till Restaurangguiden! Välj ett alternativ");
            Console.WriteLine("1. Lägg till restaurang");
            Console.WriteLine("2. Redigera restaurang");
            Console.WriteLine("3. Ta bort restaurang");
            Console.WriteLine("4. Sök restauranger");
            Console.WriteLine("5. Avsluta");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // AddRestaurant()
                    break;
                case "2":
                    // EditRestaurant()
                    break;
                case "3":
                    // DeleteRestaurant()
                    break;
                case "4":
                    // SearchRestaurants()
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
            }
        }

        // AddRestaurant(): void - frågar efter data, validerar, skapar Restaurant
        // EditRestaurant(): void - väljer restaurang och ändrar fält
        // DeleteRestaurant(): void - tar bort resturang efter bekräftelse
        // SearchRestaurants(): void - frågar efter söktext/filter och visar resultat
    }
}