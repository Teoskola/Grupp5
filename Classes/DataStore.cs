namespace Grupp5;

public class DataStore<T> where T : IIdentifiable
{
    //ATTRIBUTER
    // items: List<T> - alla objekt i minnet
    // filePath: string - sökväg till JSON-filen

    //METODER
    // AddItem(item): void - lägger till ett objekt i listan
    // RemoveItem(id): bool - tar bort objekt med givet Id
    // FindItem(id): T? - hittar objekt med givet Id, null om ej funnet
    // GetAll(): ReadOnlyList<T> - returnerar alla (skrivskyddad)
    // SaveToJson(): void - Json.Serializer.Serialize till fil (try/catch)
    // LoadFromJson(): void - läser fil, Deserialize; tom lista om filen saknas
}