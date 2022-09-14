using API_Events.Core.Models;

namespace API_Events.Core.Interfaces
{
    public interface ICityEventRepository
    {
        List<CityEvent> GetAllEvents();
        List<CityEvent> GetEventByTitle(string title);
        List<CityEvent> GetEventByLocalDate(string local, DateTime dateEvent);
        List<CityEvent> GetEventByPriceDate(decimal priceMin, decimal priceMax, DateTime dateHourEvent);
        bool InsertCityEvent(CityEvent newCityEvent);
        bool UpdateCityEvent(long idEvent, CityEvent cityEvent);
        bool DeleteCityEvent(long idEvent);

    }
}
