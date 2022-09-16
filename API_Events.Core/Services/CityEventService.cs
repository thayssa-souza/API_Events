using API_Events.Core.Interfaces.IEvents;
using API_Events.Core.Interfaces.IRepository;
using API_Events.Core.Models;

namespace API_Events.Core.Services
{
    public class CityEventService : ICityEventService
    {
        public ICityEventRepository _cityEventRepository;
        public CityEventService(ICityEventRepository cityEventRepository)
        {
            _cityEventRepository = cityEventRepository;
        }

        public async Task<List<CityEvent>> GetAllEvents()
        {
            return await _cityEventRepository.GetAllEvents();
        }

        public async Task<CityEvent> GetEventById(long idEvent)
        {
            
             return await _cityEventRepository.GetEventById(idEvent);
        }

        public async Task<List<CityEvent>> GetEventByLocalDate(string local, DateTime dateEvent)
        {
            return await _cityEventRepository.GetEventByLocalDate(local, dateEvent);
        }

        public async Task<List<CityEvent>> GetEventByTitle(string title)
        {
            return await _cityEventRepository.GetEventByTitle(title);
        }

        public async Task<List<CityEvent>> GetEventByPriceDate(decimal priceMin, decimal priceMax, DateTime dateHourEvent)
        {
            return await _cityEventRepository.GetEventByPriceDate(priceMin, priceMax, dateHourEvent);
        }
        public async Task<CityEvent> ConsultReservation(long idEvent)
        {
            return await _cityEventRepository.ConsultReservation(idEvent);
        }

        public async Task<bool> InsertCityEvent(CityEvent newCityEvent)
        {
            return await _cityEventRepository.InsertCityEvent(newCityEvent);
        }

        public async Task<bool> UpdateCityEvent(long idEvent, CityEvent cityEvent)
        {

            return await _cityEventRepository.UpdateCityEvent(idEvent, cityEvent);
        }

        public async Task<bool> InactiveCityEvent(long idEvent)
        {
            return await _cityEventRepository.InactiveCityEvent(idEvent);
        }

        public async Task<bool> ActiveCityEvent(long idEvent)
        {
            return await _cityEventRepository.ActiveCityEvent(idEvent);
        }

        public async Task<bool> DeleteCityEvent(long idEvent)
        {
             return await _cityEventRepository.DeleteCityEvent(idEvent);
        }

    }
}
