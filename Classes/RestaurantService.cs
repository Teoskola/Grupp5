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
    // Add(r): void - lägg till (ger nytt Id) och loggar
    public void Add(Restaurant restaurant)
    {
        // Validering: ogiltiga restauranger ska inte sparas
        if (string.IsNullOrWhiteSpace(restaurant.Name))
            throw new ArgumentException("Namnet får inte vara tomt.");

        if (restaurant.Rating < 1 || restaurant.Rating > 5)
            throw new ArgumentException("Betyget måste vara mellan 1 och 5.");

        // Nytt Id = högsta befintliga + 1 (börjar på 1 om listan är tom)
        restaurant.Id = store.Count == 0 ? 1 : store.Max(r => r.Id) + 1;
        // Lägg till restaurangen i listan
        store.Add(restaurant);
    }
    // Update(r): bool - ersätt befintlig restaurang, false om Id saknas
    public bool Update(Restaurant updatedRestaurant)
    {
        // Hitta index för restaurangen med samma Id
        int index = store.FindIndex(restaurant => restaurant.Id == updatedRestaurant.Id);
        // Metoden FindIndex returnerar -1 om ingen matchning hittas
        if (index == -1)
            return false; // Restaurangen med detta Id finns inte

        // Ersätt den befintliga restaurangen med den nya
        store[index] = updatedRestaurant;
        return true;
    }
    // Delete(id): bool - ta bort restaurang med Id, false om Id saknas
    public bool Delete(int id)
    {
        return store.RemoveAll(r => r.Id == id) > 0;
    }
    // GetAll(): List<Restaurant> - alla restauranger
    public List<Restaurant> GetAll()
    {
        return store;
    }
    // Search(text): List<Restaurant> - LINQ Where: namn/adress innehåller text
    // Search(text): List<Restaurant> - LINQ Where: namn/adress/område innehåller text
    public List<Restaurant> Search(string text)
    {
        // Tom söktext ger ingen träff (annars matchar allt, eller så kraschar Contains)
        if (string.IsNullOrWhiteSpace(text))
            return new List<Restaurant>();
        // LINQ Where: namn/adress/område innehåller text
        return store
            .Where(restaurant =>
                (restaurant.Name?.Contains(text, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (restaurant.Address?.Contains(text, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (restaurant.District?.Contains(text, StringComparison.OrdinalIgnoreCase) ?? false))
            .ToList();
    }
    // FilterByCuisine(c): List<Restaurant> - LINQ Where: bara valt kök
    public List<Restaurant> FilterByCuisine(CuisineType cuisine)
    {
        return store.Where(restaurant => restaurant.Cuisinetype == cuisine).ToList();
    }
    // SortByRating(): List<Restaurant> - LINQ OrderByDescending: högst betyg först
    public List<Restaurant> SortByRating()
    {
        return store.OrderByDescending(restaurant => restaurant.Rating).ToList();
    }
    // Load(): void - laddar JSON vid programstart, loggar
    // Save(): void - sparar JSON vid programavslut, loggar
}