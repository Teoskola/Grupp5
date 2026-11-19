namespace Grupp5;
using System.Text.Json;

public class DataStore<T> where T : IIdentifiable
{
    //ATTRIBUTER
    // items: List<T> - alla objekt i minnet
    private List<T> items = new List<T>();
    // filePath: string - sökväg till JSON-filen
    private string filePath = "restaurants.json";

    //METODER
    // AddItem(item): void - lägger till ett objekt i listan
    public void AddItem(T item)
    {      
      items.Add(item);
    }

    // RemoveItem(id): bool - tar bort objekt med givet Id
    public bool RemoveItem(int id)
    {
        return items.RemoveAll(item => item.Id == id) > 0;
    }

    // FindItem(id): T? - hittar objekt med givet Id, null om ej funnet
    public T? FindItem(int id)
    {
        return items.FirstOrDefault(item => item.Id == id);
    }
    // GetAll(): ReadOnlyList<T> - returnerar alla (skrivskyddad)
    public IReadOnlyList<T> GetAll()
    {
        return items;
    }

    // SaveToJson(): void - Json.Serializer.Serialize till fil (try/catch)
    public void SaveToJson()
    {
        try
        {
            var json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to JSON: {ex.Message}");
        }
    }

    // LoadFromJson(): void - läser fil, Deserialize; tom lista om filen saknas
}