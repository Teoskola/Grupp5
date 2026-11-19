namespace Grupp5;

public class RestaurantService

{
    //ATTRIBUTER
    // Datastore<Restaurant> - listan + JSON-hanteringen
    private DataStore<Restaurant> store = new DataStore<Restaurant>();
    // log: LogService - för att logga händelser och fel
    private LogService log = new LogService();

    //METODER
    // Add(r): void - lägg till (ger nytt Id) och loggar
    public void Add(Restaurant restaurant)
    {
        // Validering: ogiltiga restauranger ska inte sparas
        if (string.IsNullOrWhiteSpace(restaurant.Name))
            throw new ArgumentException("Namnet får inte vara tomt.");

        if (restaurant.Rating < 1 || restaurant.Rating > 5)
            throw new ArgumentException("Betyget måste vara mellan 1 och 5.");
        
        // Nytt Id = högsta befintliga + 1 (börjar på 1 om listan är tom)
        restaurant.Id = store.GetAll().Count == 0 ? 1 : store.GetAll().Max(r => r.Id) + 1;

        // Lägg till restaurangen i listan
        store.AddItem(restaurant);
        log.LogEvent($"{restaurant.Name} - {restaurant.Address} har lagts till");
    }
    // Update(r): bool - ersätt befintlig restaurang, false om Id saknas
    public bool Update(Restaurant updatedRestaurant)
    {
        var existing = store.FindItem(updatedRestaurant.Id);

        if (existing == null)
        {
            log.LogEvent($"Försökte uppdatera Id {updatedRestaurant.Id}, men ingen hittades");
            return false;
        }

        log.LogEvent($"{updatedRestaurant.Name} har uppdaterats");
        return true;
    }

    // Delete(id): bool - ta bort restaurang med Id, false om Id saknas
    public bool Delete(int id)
    {
        bool removed = store.RemoveItem(id);

        if (removed)
        {
            log.LogEvent($"Restaurang med Id {id} har tagits bort");
        }
        else
        {
            log.LogEvent($"Försökte ta bort Id {id}, men ingen hittades");
        }
        return removed;
    }
    // GetAll(): List<Restaurant> - alla restauranger
    public List<Restaurant> GetAll()
    {
        return store.GetAll().ToList();
    }
    
    // Search(text): List<Restaurant> - LINQ Where: namn/adress innehåller text
    // Search(text): List<Restaurant> - LINQ Where: namn/adress/område innehåller text
    public List<Restaurant> Search(string text)
    {
        // Tom söktext ger ingen träff (annars matchar allt, eller så kraschar Contains)
        if (string.IsNullOrWhiteSpace(text))
            return new List<Restaurant>();
        // LINQ Where: namn/adress/område innehåller text
        return store.GetAll()
            .Where(restaurant =>
                (restaurant.Name?.Contains(text, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (restaurant.Address?.Contains(text, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (restaurant.District?.Contains(text, StringComparison.OrdinalIgnoreCase) ?? false))
            .ToList();
    }
    // FilterByCuisine(c): List<Restaurant> - LINQ Where: bara valt kök
    // public DataStore<Restaurant> FilterByCuisine(CuisineType cuisine)
    // {
    //     return store.Where(restaurant => restaurant.Cuisinetype == cuisine).ToList();
    // }
    // // SortByRating(): List<Restaurant> - LINQ OrderByDescending: högst betyg först
    // public DataStore<Restaurant> SortByRating()
    // {
    //     return store.OrderByDescending(restaurant => restaurant.Rating).ToList();
    // }
    // Load(): void - laddar JSON vid programstart, loggar
    public void Load()
    {
        store.LoadFromJson();
        log.LogEvent("Restauranger har laddats från JSON-fil");
    }
    // Save(): void - sparar JSON vid programavslut, loggar
}