using API_Events.Core.Models;

namespace API_Events.Core.Interfaces.IEvents
{
    public interface ICityEventService
    {
        Task<List<CityEvent>> GetAllEvents();
        Task<CityEvent> GetEventById(long idEvent);
        Task<List<CityEvent>> GetEventByTitle(string title);
        Task<List<CityEvent>> GetEventByLocalDate(string local, DateTime dateEvent);
        Task<List<CityEvent>> GetEventByPriceDate(decimal priceMin, decimal priceMax, DateTime dateHourEvent);
        Task<bool> InsertCityEvent(CityEvent newCityEvent);
        Task<bool> UpdateCityEvent(long idEvent, CityEvent cityEvent);
        Task<bool> UpdateEventStatus(long idEvent);
        Task<bool> DeleteCityEvent(long idEvent);
    }
}
