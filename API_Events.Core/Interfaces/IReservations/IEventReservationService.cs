using API_Events.Core.Models;

namespace API_Events.Core.Interfaces.IReservations
{
    public interface IEventReservationService
    {
        List<EventReservation> GetReservationList();
        EventReservation GetReservationById(long idReservation);
        List<EventReservation> GetReservationEventByPerson(string title, string personName);
        bool InsertReservation(long idEvent, string personName, long quantity);
        bool UpdateQuantityReservation(long idReservation, long quantity);
        bool DeleteReservation(long idReservation);
    }
}
