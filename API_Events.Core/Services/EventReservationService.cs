using API_Events.Core.Interfaces.IReservations;
using API_Events.Core.Models;

namespace API_Events.Core.Services
{
    public class EventReservationService : IEventReservationService
    {
        public IEventReservationRepository _eventReservationRepository;
        public EventReservationService(IEventReservationRepository eventReservationRepository)
        {
            _eventReservationRepository = eventReservationRepository;
        }

        public Task<List<EventReservation>> GetReservationList()
        {
            return await _eventReservationRepository.GetReservationList();
        }

        public Task<EventReservation> GetReservationById(long idReservation)
        {
            return await _eventReservationRepository.GetReservationById(idReservation);
        }

        public Task<List<EventReservation>> GetReservationEventByPerson(string title, string personName)
        {
            return await _eventReservationRepository.GetReservationEventByPerson(title, personName);
        }

        public Task<bool> InsertReservation(long idEvent, string personName, long quantity)
        {
            return await _eventReservationRepository.InsertReservation(idEvent, personName, quantity);
        }

        public Task<bool> UpdateQuantityReservation(long idReservation, long quantity)
        {
            return await _eventReservationRepository.UpdateQuantityReservation(idReservation, quantity);
        }

        public Task<bool> DeleteReservation(long idReservation)
        {
            try
            {
                return await _eventReservationRepository.DeleteReservation(idReservation);
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
