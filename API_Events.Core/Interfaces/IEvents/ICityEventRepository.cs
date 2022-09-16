using API_Events.Core.Models;

namespace API_Events.Core.Interfaces.IRepository
{
    public interface ICityEventRepository
    {
        Task<List<CityEvent>> GetAllEvents();
        Task<CityEvent> GetEventById(long idEvent);
        Task<List<CityEvent>> GetEventByTitle(string title);
        Task<List<CityEvent>> GetEventByLocalDate(string local, DateTime dateEvent);
        Task<List<CityEvent>> GetEventByPriceDate(decimal priceMin, decimal priceMax, DateTime dateHourEvent);
        Task<CityEvent> ConsultReservation(long idEvent);
        Task<bool> InsertCityEvent(CityEvent newCityEvent);
        Task<bool> UpdateCityEvent(long idEvent, CityEvent cityEvent);
        Task<bool> InactiveCityEvent(long idEvent);
        Task<bool> ActiveCityEvent(long idEvent);
        Task<bool> DeleteCityEvent(long idEvent);

    }
}
