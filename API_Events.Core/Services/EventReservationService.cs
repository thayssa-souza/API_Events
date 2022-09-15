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
        public EventReservation GetReservationById(long idReservation)
        {
            return _eventReservationRepository.GetReservationById(idReservation);
        }

        public List<EventReservation> GetReservationList()
        {
            return _eventReservationRepository.GetReservationList();
        }

        public List<EventReservation> GetReservationEventByPerson(string title, string personName)
        {
            return _eventReservationRepository.GetReservationEventByPerson(title, personName);
        }

        public bool InsertReservation(long idEvent, string personName, long quantity)
        {
            return _eventReservationRepository.InsertReservation(idEvent, personName, quantity);
        }

        public bool UpdateQuantityReservation(long idReservation, long quantity)
        {
            return _eventReservationRepository.UpdateQuantityReservation(idReservation, quantity);
        }

        public bool DeleteReservation(long idReservation)
        {
            return _eventReservationRepository.DeleteReservation(idReservation);
        }
    }
}
