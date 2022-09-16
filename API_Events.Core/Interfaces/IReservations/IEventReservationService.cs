using API_Events.Core.Models;

namespace API_Events.Core.Interfaces.IReservations
{
    public interface IEventReservationService
    {
        Task<List<EventReservation>> GetReservationList();
        Task<EventReservation> GetReservationById(long idReservation);
        Task<List<EventReservation>> GetReservationEventByPerson(string title, string personName);
        Task<bool> InsertReservation(long idEvent, string personName, long quantity);
        Task<bool> UpdateQuantityReservation(long idReservation, long quantity);
        Task<bool> DeleteReservation(long idReservation);
    }
}
