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

    // GetTopRated(n): List<Restaurant> - topplista: den högst betygsatta
    public List<Restaurant> GetTopRated(int number)
    {
        return restaurants.GetAll()
            .OrderByDescending(restaurant => restaurant.Rating)
            .Take(number)
            .ToList();
    }
}