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

        public CityEvent GetSpecificEvent(long id)
        {
            return _cityEventRepository.GetSpecificEvent(id);
        }
    }
}
