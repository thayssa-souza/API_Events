using API_Events.Core.Models;

namespace API_Events.Core.Interfaces
{
    public interface ICityEventRepository
    {
        List<CityEvent> GetCityEvents();
        List<CityEvent> GetEventByTitle(string title);
        bool InsertCityEvent(CityEvent newCityEvent);
        bool UpdateCityEvent(long id, CityEvent cityEvent);
    }
}
