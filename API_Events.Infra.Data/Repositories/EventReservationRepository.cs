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

        public async Task<List<EventReservation>> GetReservationList()
        {
            var query = "SELECT * FROM EventReservation";
            using var conn = _cnnDataBase.CreateConnection();
            return (await conn.QueryAsync<EventReservation>(query)).ToList();
        }

        public async Task<EventReservation> GetReservationById(long idReservation)
        {
            var query = "SELECT * FROM EventReservation WHERE IdReservation = @idReservation";
            var parameters = new DynamicParameters(new { idReservation, });

            using var conn = _cnnDataBase.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<EventReservation>(query, parameters);
        }

        public async Task<List<EventReservation>> GetReservationEventByPerson(string title, string personName)
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
            return (await conn.QueryAsync<EventReservation>(query, parameters)).ToList();
        }

        public async Task<bool> InsertReservation(long idEvent, string personName, long quantity)
        {
            var query = "INSERT INTO EventReservation VALUES (@idEvent, @PersonName, @Quantity)";
            var parameters = new DynamicParameters(new
            {
                idEvent,
                personName,
                quantity,
            });
            using var conn = _cnnDataBase.CreateConnection();
            return await conn.ExecuteAsync(query, parameters) == 1;
        }

        public async Task<bool> UpdateQuantityReservation(long idReservation, long quantity)
        {
            var query = "UPDATE EventReservation SET Quantity = @quantity WHERE IdReservation = @idReservation";
            var parameters = new DynamicParameters(new
            {
                idReservation,
                quantity,
            });
            using var conn = _cnnDataBase.CreateConnection();
            return await conn.ExecuteAsync(query, parameters) == 1;
        }

        public async Task<bool> DeleteReservation(long idReservation)
        {
            var query = "DELETE FROM EventReservation WHERE IdReservation = @idReservation";
            var parameters = new { idReservation };
            using var conn = _cnnDataBase.CreateConnection();
            return await conn.ExecuteAsync(query, parameters) == 1;
        }
    }
}
