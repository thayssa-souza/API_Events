using API_Events.Core.Models;

namespace API_Events.Core.Interfaces
{
    public interface ICityEventRepository
    {
        List<CityEvent> GetCityEvents();
        CityEvent GetSpecificEvent(long id);
    }
}
