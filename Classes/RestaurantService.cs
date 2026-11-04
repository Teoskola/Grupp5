namespace Grupp5;

public class RestaurantService

{
    //ATTRIBUTER
    // Datastore<Restaurant> - listan + JSON-hanteringen
    // Jag gör en tillfällig lista här för att kunna testa utan JSON, men den ska ersättas med Datastore<Restaurant> senare
    private List<Restaurant> store = new List<Restaurant>();
    // log: LogService - för att logga händelser och fel

    //METODER
    // Add(r): void - lägg till (get nytt Id) och loggar
    // Update(r): bool - ersätt befintlig restaurang, false om Id saknas
    // Delete(id): bool - ta bort restaurang med Id, false om Id saknas
    // GetAll(): List<Restaurant> - alla restauranger
    public List<Restaurant> GetAll()
    {
        return store;
    }
    // Search(text): List<Restaurant> - LINQ Where: namn/adress innehåller text
    // FilterByCuisine(c): List<Restaurant> - LINQ Where: bara valt kök
    // SortByRating(): List<Restaurant> - LINQ OrderByDescending: högst betyg först
    // Load(): void - laddar JSON vid programstart, loggar
    // Save(): void - sparar JSON vid programavslut, loggar
}