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

        public async Task<List<EventReservation>> GetReservationList()
        {
            return await _eventReservationRepository.GetReservationList();
        }

        public async Task<EventReservation> GetReservationById(long idReservation)
        {
            return await _eventReservationRepository.GetReservationById(idReservation);
        }

        public async Task<List<EventReservation>> GetReservationEventByPerson(string title, string personName)
        {
            return await _eventReservationRepository.GetReservationEventByPerson(title, personName);
        }

        public async Task<bool> InsertReservation(long idEvent, string personName, long quantity)
        {
            return await _eventReservationRepository.InsertReservation(idEvent, personName, quantity);
        }

        public async Task<bool> UpdateQuantityReservation(long idReservation, long quantity)
        {
            return await _eventReservationRepository.UpdateQuantityReservation(idReservation, quantity);
        }

        public async Task<bool> DeleteReservation(long idReservation)
        {
            return await _eventReservationRepository.DeleteReservation(idReservation);
        }
    }
}
