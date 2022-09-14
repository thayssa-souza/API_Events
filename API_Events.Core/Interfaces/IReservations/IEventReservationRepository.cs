using API_Events.Core.Models;

namespace API_Events.Core.Interfaces.IReservations
{
    public interface IEventReservationRepository
    {
        List<EventReservation> GetReservationList();
        List<EventReservation> GetReservationEventByPerson(string title, string personName);
        bool InsertReservation(EventReservation newEventReservation);
        bool UpdateQuantityReservation(long idReservation, EventReservation newEventReservation);
        bool DeleteReservation(long idReservation);

    }
}
