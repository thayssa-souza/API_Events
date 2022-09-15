using API_Events.Core.Models;

namespace API_Events.Core.Interfaces.IReservations
{
    public interface IEventReservationService
    {
        List<EventReservation> GetReservationList();
        EventReservation GetReservationById(long idReservation);
        List<EventReservation> GetReservationEventByPerson(string title, string personName);
        bool InsertReservation(EventReservation newEventReservation);
        bool UpdateQuantityReservation(long idReservation, EventReservation eventReservation);
        bool DeleteReservation(long idReservation);
    }
}
