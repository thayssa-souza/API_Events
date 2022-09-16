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

        public Task<List<CityEvent>> GetAllEvents()
        {
            return await _cityEventRepository.GetAllEvents();
        }

        public Task<CityEvent> GetEventById(long idEvent)
        {
            
             return await _cityEventRepository.GetEventById(idEvent);
        }

        public Task<List<CityEvent>> GetEventByLocalDate(string local, DateTime dateEvent)
        {
            return await _cityEventRepository.GetEventByLocalDate(local, dateEvent);
        }

        public Task<List<CityEvent>> GetEventByTitle(string title)
        {
            return await _cityEventRepository.GetEventByTitle(title);
        }

        public Task<List<CityEvent>> GetEventByPriceDate(decimal priceMin, decimal priceMax, DateTime dateHourEvent)
        {
            return await _cityEventRepository.GetEventByPriceDate(priceMin, priceMax, dateHourEvent);
        }

        public Task<bool> InsertCityEvent(CityEvent newCityEvent)
        {
            return await _cityEventRepository.InsertCityEvent(newCityEvent);
        }

        public Task<bool> UpdateCityEvent(long idEvent, CityEvent cityEvent)
        {

            return await _cityEventRepository.UpdateCityEvent(idEvent, cityEvent);
        }

        public async Task<bool> UpdateEventStatus(long idEvent)
        {
            return await _cityEventRepository.UpdateStatusEvent(idEvent);
        }

        public Task<bool> DeleteCityEvent(long idEvent)
        {
            try
            {
                return await _cityEventRepository.DeleteCityEvent(idEvent);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Erro - Valor nulo! Mensagem {ex.Message},  stack trace {ex.StackTrace}, {ex.TargetSite}");
                return await false;
            }
            catch (Exception ex)
            {
                var nameException = ex.GetType().Name;

                Console.WriteLine($"Erro - {nameException}. Mensagem {ex.Message},  stack trace {ex.StackTrace}, {ex.TargetSite}");
                return await false;
            }
        }
    }
}
