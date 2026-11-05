namespace Grupp5;

public class StatisticsService
{
    //ATTRIBUTER
    // restaurants: RestaurantService - källan till datan
    private RestaurantService restaurants;

    public StatisticsService(RestaurantService restaurantService)
    {
        restaurants = restaurantService;
    }

    //METODER
    // CountByCuisine(): Dictionary - LINQ GroupBy: antal restauranger per kök
    public Dictionary<CuisineType, int> CountByCuisine()
    {
        return restaurants.GetAll()
            .GroupBy(cuisine => cuisine.Cuisinetype)
            .ToDictionary(grupp => grupp.Key, grupp => grupp.Count());
    }

    // AverageRating(): double - snittbetyg (0 om listan är tom)
    // GetTopRated(n): List<Restaurant> - topplista: den högst betygsatta
}