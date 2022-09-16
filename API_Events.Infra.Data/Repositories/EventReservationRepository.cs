using API_Events.Core.Interfaces;
using API_Events.Core.Interfaces.IReservations;
using API_Events.Core.Models;
using Aspose.Pdf.Operators;
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
            try
            {
                using var conn = _cnnDataBase.CreateConnection();
                return (await conn.QueryAsync<EventReservation>(query)).ToList();
            }
            catch (Exception ex)
            {
                var nameException = ex.GetType().Name;
                Console.WriteLine($"Erro - {nameException}. Mensagem {ex.Message},  stack trace {ex.StackTrace}, {ex.TargetSite}");
                throw;
            }
        }

        public async Task<EventReservation> GetReservationById(long idReservation)
        {
            var query = "SELECT * FROM EventReservation WHERE IdReservation = @idReservation";
            var parameters = new DynamicParameters(new { idReservation, });
            try
            {
                using var conn = _cnnDataBase.CreateConnection();
                return await conn.QueryFirstOrDefaultAsync<EventReservation>(query, parameters);
            }
            catch (Exception ex)
            {
                var nameException = ex.GetType().Name;
                Console.WriteLine($"Erro - {nameException}. Mensagem {ex.Message},  stack trace {ex.StackTrace}, {ex.TargetSite}");
                throw;
            }
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

            try
            {
                using var conn = _cnnDataBase.CreateConnection();
                return (await conn.QueryAsync<EventReservation>(query, parameters)).ToList();
            }
            catch (Exception ex)
            {
                var nameException = ex.GetType().Name;
                Console.WriteLine($"Erro - {nameException}. Mensagem {ex.Message},  stack trace {ex.StackTrace}, {ex.TargetSite}");
                throw;
            }
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

            try
            {
                using var conn = _cnnDataBase.CreateConnection();
                return await conn.ExecuteAsync(query, parameters) == 1;
            }
            catch (Exception ex)
            {
                var nameException = ex.GetType().Name;
                Console.WriteLine($"Erro - {nameException}. Mensagem {ex.Message},  stack trace {ex.StackTrace}, {ex.TargetSite}");
                throw;
            }
        }

        public async Task<bool> UpdateQuantityReservation(long idReservation, long quantity)
        {
            var query = "UPDATE EventReservation SET Quantity = @quantity WHERE IdReservation = @idReservation";
            var parameters = new DynamicParameters(new
            {
                idReservation,
                quantity,
            });

            try
            {
                using var conn = _cnnDataBase.CreateConnection();
                return await conn.ExecuteAsync(query, parameters) == 1;
            }
            catch (Exception ex)
            {
                var nameException = ex.GetType().Name;
                Console.WriteLine($"Erro - {nameException}. Mensagem {ex.Message},  stack trace {ex.StackTrace}, {ex.TargetSite}");
                throw;
            }
        }

        public async Task<bool> DeleteReservation(long idReservation)
        {
            var query = "DELETE FROM EventReservation WHERE IdReservation = @idReservation";
            var parameters = new { idReservation };

            try
            {
                using var conn = _cnnDataBase.CreateConnection();
                return await conn.ExecuteAsync(query, parameters) == 1;
            }
            catch (Exception ex)
            {
                var nameException = ex.GetType().Name;
                Console.WriteLine($"Erro - {nameException}. Mensagem {ex.Message},  stack trace {ex.StackTrace}, {ex.TargetSite}");
                throw;
            }
        }
    }
}
