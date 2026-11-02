namespace grupp5.Models;

/// <summary>
/// Ett kontrakt (interface): "Allt som sparas i DataStore måste ha ett unikt Id."
/// Ett interface innehåller bara regler, ingen riktig kod.
/// </summary>
public interface IIdentifiable
{
	/// <summary>
	/// Unikt nummer för varje objekt.
	/// DataStore använder det för att hitta (FindItem) och ta bort (RemoveItem).
	/// </summary>
	int Id { get; set; }
}
 