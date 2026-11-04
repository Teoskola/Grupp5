namespace Grupp5;

public class StatisticsService
{
    //ATTRIBUTER
    // restaurants: RestaurantService - källan till datan

    //METODER
    // CountByCuisine(): Dictionary - LINQ GroupBy: antal restauranger per kök
    // AverageRating(): double - snittbetyg (0 om listan är tom)
    // GetTopRated(n): List<Restaurant> - topplista: den högst betygsatta
}