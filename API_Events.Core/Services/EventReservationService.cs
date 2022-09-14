using API_Events.Core.Interfaces.IReservations;
using API_Events.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool UpdateQuantityReservation(long quantity, EventReservation newEventReservation)
        {
            return _eventReservationRepository.UpdateQuantityReservation(quantity, newEventReservation);
        }

        public bool DeleteReservation(long idReservation)
        {
            return _eventReservationRepository.DeleteReservation(idReservation);
        }
    }
}
