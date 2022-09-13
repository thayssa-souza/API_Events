using API_Events.Core.Interfaces;
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

        public List<CityEvent> GetCityEvents()
        {
            return _cityEventRepository.GetCityEvents();
        }

        public List<CityEvent> GetEventByTitle(string title)
        {
            return _cityEventRepository.GetEventByTitle(title);
        }

        public bool InsertCityEvent(CityEvent newCityEvent)
        {
            return _cityEventRepository.InsertCityEvent(newCityEvent);
        }

        public bool UpdateCityEvent(long id, CityEvent cityEvent)
        {
            return _cityEventRepository.UpdateCityEvent(id, cityEvent);
        }
    }
}
