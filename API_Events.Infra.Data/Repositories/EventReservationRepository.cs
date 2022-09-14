using API_Events.Core.Interfaces;
using API_Events.Core.Interfaces.IReservations;
using API_Events.Core.Models;
using Dapper;

namespace API_Events.Infra.Data.Repositories
{
    public class EventReservationRepository : IEventReservationRepository
    {
        private readonly IConnectionDataBase _cnnDataBase;
        public EventReservationRepository(IConnectionDataBase cnnDataBase)
        {
            _cnnDataBase = cnnDataBase;
        }

        public List<EventReservation> GetReservationList()
        {
            var query = "SELECT * FROM EventReservation";
            using var conn = _cnnDataBase.CreateConnection();
            return conn.Query<EventReservation>(query).ToList();
        }

        public List<EventReservation> GetReservationEventByPerson(string title, string personName)
        {
            throw new NotImplementedException();
        }

        public bool InsertReservation(EventReservation newEventReservation)
        {
            throw new NotImplementedException();
        }

        public bool UpdateQuantityReservation(long quantity, EventReservation newEventReservation)
        {
            throw new NotImplementedException();
        }

        public bool DeleteReservation(long idReservation)
        {
            throw new NotImplementedException();
        }
    }
}
