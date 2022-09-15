using API_Events.Core.Models;

namespace API_Events.Core.Interfaces.IRepository
{
    public interface ICityEventRepository
    {
        List<CityEvent> GetAllEvents();
        CityEvent GetEventById(long idEvent);
        List<CityEvent> GetEventByTitle(string title);
        List<CityEvent> GetEventByLocalDate(string local, DateTime dateEvent);
        List<CityEvent> GetEventByPriceDate(decimal priceMin, decimal priceMax, DateTime dateHourEvent);
        bool InsertCityEvent(CityEvent newCityEvent);
        bool UpdateCityEvent(long idEvent, CityEvent cityEvent);
        bool DeleteCityEvent(long idEvent);

    }
}
