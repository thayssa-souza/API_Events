using API_Events.Core.Models;

namespace API_Events.Core.Interfaces
{
    public interface ICityEventService
    {
        public List<CityEvent> GetCityEvents();
        public CityEvent GetSpecificEvent(long id);
    }
}
