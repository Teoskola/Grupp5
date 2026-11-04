namespace Grupp5;


    public class Restaurant : IIdentifiable
    {
        //ATTRIBUTER
        // Id: int - unikt id (från IIdentifiable)
        public int Id { get; set; }
        // Name: string - restaurangens namn
        public string ?Name { get; set; }
        // Cuisinetype: CusineType - typ av kök (från CuisineType)
        public CuisineType Cuisinetype { get; set; }
        // Disctric: string - stadsdel där restaurangen ligger
        public string ?District { get; set; }
        // Address: string - adressen till restaurangen
        public string ?Address { get; set; }
        // Rating: double - betyg 1-5
        public double Rating { get; set; }
        // PriceLevel: PriceLevel - billig / medel / dyr
        public PriceLevel PriceLevel { get; set; }
        // IsVegetarianFriendly: bool - true om restaurangen är vegetariskvänlig, annars false
        public bool IsVegetarianFriendly { get; set; }

        //METODER
        // GetSummary(): string - kort text för visning
        public string GetSummary()
        {
            return $"{Name} - {Cuisinetype} - {District} - {Address} - Rating: {Rating} - Price Level: {PriceLevel} - Vegetarian Friendly: {IsVegetarianFriendly}";
        }
    
    }

