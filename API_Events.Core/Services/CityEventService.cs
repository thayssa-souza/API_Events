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

        public List<CityEvent> GetAllEvents()
        {
            return _cityEventRepository.GetAllEvents();
        }

        public List<CityEvent> GetEventByLocalDate(string local, DateTime dateEvent)
        {
            return _cityEventRepository.GetEventByLocalDate(local, dateEvent);
        }

        public List<CityEvent> GetEventByTitle(string title)
        {
            return _cityEventRepository.GetEventByTitle(title);
        }

        public List<CityEvent> GetEventByPriceDate(decimal priceMin, decimal priceMax, DateTime dateHourEvent)
        {
            return _cityEventRepository.GetEventByPriceDate(priceMin, priceMax, dateHourEvent);
        }

        public bool InsertCityEvent(CityEvent newCityEvent)
        {
            return _cityEventRepository.InsertCityEvent(newCityEvent);
        }

        public bool UpdateCityEvent(long idEvent, CityEvent cityEvent)
        {
            return _cityEventRepository.UpdateCityEvent(idEvent, cityEvent);
        }

        public bool DeleteCityEvent(long idEvent)
        {
            return _cityEventRepository.DeleteCityEvent(idEvent);
        }

    }
}
