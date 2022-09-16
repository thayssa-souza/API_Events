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

        public EventReservation GetReservationById(long idReservation)
        {
            var query = "SELECT * FROM EventReservation WHERE IdReservation = @idReservation";
            var parameters = new DynamicParameters(new { idReservation, });

            using var conn = _cnnDataBase.CreateConnection();
            return conn.QueryFirstOrDefault<EventReservation>(query, parameters);
        }

        public List<EventReservation> GetReservationEventByPerson(string title, string personName)
        {
            var query = $"SELECT * FROM EventReservation AS event " +
                $"INNER JOIN CityEvent AS city ON event.PersonName = @personName AND city.Title LIKE ('%' + @title + '%') " +
                $"WHERE event.IdEvent = city.IdEvent";
            var parameters = new DynamicParameters(new
            {
                title, 
                personName,
            });
            using var conn = _cnnDataBase.CreateConnection();
            return conn.Query<EventReservation>(query, parameters).ToList();
        }

        public bool InsertReservation(long idEvent, string personName, long quantity)
        {
            var query = "INSERT INTO EventReservation VALUES (@idEvent, @PersonName, @Quantity)";
            var parameters = new DynamicParameters(new
            {
                idEvent,
                personName,
                quantity,
            });
            using var conn = _cnnDataBase.CreateConnection();
            return conn.Execute(query, parameters) == 1;
        }

        public bool UpdateQuantityReservation(long idReservation, long quantity)
        {
            var query = "UPDATE EventReservation SET Quantity = @quantity WHERE IdReservation = @idReservation";
            var parameters = new DynamicParameters(new
            {
                idReservation,
                quantity,
            });
            using var conn = _cnnDataBase.CreateConnection();
            return conn.Execute(query, parameters) == 1;
        }

        public bool DeleteReservation(long idReservation)
        {
            var query = "DELETE FROM EventReservation WHERE IdReservation = @idReservation";
            var parameters = new { idReservation };
            using var conn = _cnnDataBase.CreateConnection();
            return conn.Execute(query, parameters) == 1;
        }
    }
}
