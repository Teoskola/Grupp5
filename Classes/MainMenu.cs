using Spectre.Console;

namespace Grupp5;

/// <summary>
/// Huvudmenyn (UI-delen). Visar en meny med pilval, tar emot användarens val
/// och anropar rätt metod. Menyn sköter bara frågor och utskrifter, medan
/// själva logiken (spara, söka, ta bort) ligger i RestaurantService.
/// </summary>
public class MainMenu
{
    // ATTRIBUTER

    // Referens till servicen som hanterar restaurangerna.
    // "private" = bara MainMenu kan använda den.
    // "readonly" = värdet sätts en gång (i konstruktorn) och kan inte bytas ut senare.
    private readonly RestaurantService restaurants;

    // KONSTRUKTOR

    /// <summary>
    /// Körs när man skriver "new MainMenu(service)" i Program.cs.
    /// Menyn får ett RestaurantService-objekt utifrån och sparar det i fältet,
    /// så att alla metoder i klassen kan använda det.
    /// </summary>
    /// <param name="restaurants">Servicen som menyn ska anropa.</param>
    public MainMenu(RestaurantService restaurants)
    {
        // "this.restaurants" är fältet i klassen,
        // "restaurants" är parametern som skickades in. Här kopplas de ihop.
        this.restaurants = restaurants;
    }

    // METODER

    /// <summary>
    /// Huvudloopen. Visar menyn, läser användarens val, kör rätt metod
    /// och börjar om, tills användaren väljer "Avsluta".
    /// </summary>
    public void Run()
    {
        while (true)   // upprepas tills "return" körs
        {
            // Rensa skärmen och rita rubriken med stora bokstäver
            AnsiConsole.Clear();
            AnsiConsole.Write(new FigletText("Restaurangguiden").Color(Color.Green));

            // Visar en lista som användaren väljer ur med piltangenterna (↑/↓) och Enter.
            // Det som returneras är texten på alternativet som valdes.
            string choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Vad vill du göra?[/]")   // [green]...[/] = färgad text
                    .PageSize(10)                            // max antal rader som visas åt gången
                    .AddChoices(
                        "Visa alla restauranger",
                        "Lägg till restaurang",
                        "Redigera restaurang",
                        "Ta bort restaurang",
                        "Sök restauranger",
                        "Avsluta"));

            // Skicka vidare till rätt metod beroende på valet.
            // Texten i "case" måste vara exakt samma som i AddChoices ovan.
            switch (choice)
            {
                case "Visa alla restauranger":
                    ShowAllRestaurants();
                    break;
                case "Lägg till restaurang":
                    AddRestaurant();
                    break;
                case "Redigera restaurang":
                    EditRestaurant();
                    break;
                case "Ta bort restaurang":
                    DeleteRestaurant();
                    break;
                case "Sök restauranger":
                    SearchRestaurants();
                    break;
                case "Avsluta":
                    return;   // lämnar Run() och därmed programmet
            }

            // Utan paus skulle skärmen rensas direkt i nästa varv,
            // och användaren hinner inte läsa resultatet.
            AnsiConsole.MarkupLine("\n[grey]Tryck på valfri tangent för att fortsätta...[/]");
            Console.ReadKey(true);   // true = visa inte tangenten som skrivs
        }
    }

    // ShowAllRestaurants(): void - visar alla restauranger
    // Tips: hämta listan med restaurants.GetAll() och skriv ut en rad per restaurang.
    private void ShowAllRestaurants()
    {
        AnsiConsole.MarkupLine("[grey]Inte klar än.[/]");
    }

    // AddRestaurant(): void - frågar efter data, validerar, skapar Restaurant
    // Tips: fråga efter namn, adress, område, kök, prisnivå, betyg och vegetariskt,
    // skapa en Restaurant och anropa restaurants.Add(...) i en try/catch.
    private void AddRestaurant()
    {
        AnsiConsole.MarkupLine("[grey]Inte klar än.[/]");
    }

    // EditRestaurant(): void - väljer restaurang och ändrar fält
    // Tips: fråga efter Id, hitta restaurangen, fråga efter nya värden
    // och anropa restaurants.Update(...).
    private void EditRestaurant()
    {
        AnsiConsole.MarkupLine("[grey]Inte klar än.[/]");
    }

    // DeleteRestaurant(): void - tar bort restaurang efter bekräftelse
    // Tips: fråga efter Id, be om bekräftelse och anropa restaurants.Delete(id).
    private void DeleteRestaurant()
    {
        AnsiConsole.MarkupLine("[grey]Inte klar än.[/]");
    }

    // SearchRestaurants(): void - frågar efter söktext och visar resultat
    // Tips: fråga efter text, anropa restaurants.Search(text) och skriv ut träffarna.
    private void SearchRestaurants()
    {
        AnsiConsole.MarkupLine("[grey]Inte klar än.[/]");
    }
}