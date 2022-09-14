using API_Events.Core.Models;

namespace API_Events.Core.Interfaces
{
    public interface ICityEventService
    {
        List<CityEvent> GetAllEvents();
        List<CityEvent> GetEventByTitle(string title);
        List<CityEvent> GetEventByLocalDate(string local, DateTime dateEvent);
        bool InsertCityEvent(CityEvent newCityEvent);
        bool UpdateCityEvent(long idEvent, CityEvent cityEvent);
    }
}
