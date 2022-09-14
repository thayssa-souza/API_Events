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

        public List<EventReservation> GetReservationList()
        {
            return _eventReservationRepository.GetReservationList();
        }

        public List<EventReservation> GetReservationEventByPerson(string title, string personName)
        {
            return _eventReservationRepository.GetReservationEventByPerson(title, personName);
        }

        public bool InsertReservation(EventReservation newEventReservation)
        {
            return _eventReservationRepository.InsertReservation(newEventReservation);
        }

        public bool UpdateQuantityReservation(long idReservation, EventReservation eventReservation)
        {
            return _eventReservationRepository.UpdateQuantityReservation(idReservation, eventReservation);
        }

        public bool DeleteReservation(long idReservation)
        {
            return _eventReservationRepository.DeleteReservation(idReservation);
        }
    }
}
