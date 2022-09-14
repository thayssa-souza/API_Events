using API_Events.Core.Interfaces;
using API_Events.Core.Models;
using Dapper;

namespace API_Events.Infra.Data.Repositories
{
    public class CityEventRepository : ICityEventRepository
    {
        private readonly IConnectionDataBase _cnnDataBase;

        public CityEventRepository(IConnectionDataBase cnnDataBase)
        {
            _cnnDataBase = cnnDataBase;
        }

        public List<CityEvent> GetAllEvents()
        {
            var query = "SELECT * FROM CityEvent";
            using var conn = _cnnDataBase.CreateConnection();
            return conn.Query<CityEvent>(query).ToList();
        }

        public List<CityEvent> GetEventByTitle(string title)
        {
            var query = $"SELECT * FROM CityEvent WHERE title LIKE ('%' + @title + '%')";
            var parameters = new DynamicParameters(new
            {
                title,
            });

            using var conn = _cnnDataBase.CreateConnection();
            return conn.Query<CityEvent>(query, parameters).ToList();
        }

        public List<CityEvent> GetEventByLocalDate(string local, DateTime dateHourEvent)
        {
            var query = $"SELECT * FROM CityEvent WHERE local LIKE ('%' + @local + '%') AND CONVERT (DATE, DateHourEvent) = @dateHourEvent";
            var parameters = new DynamicParameters(new
            {
                Local = local,
                DateHourEvent = dateHourEvent,
            });

            using var conn = _cnnDataBase.CreateConnection();
            return conn.Query<CityEvent>(query, parameters).ToList();
        }

        public bool InsertCityEvent(CityEvent newCityEvent)
        {
            var query = "INSERT INTO CityEvent VALUES (@Title, @Description, @DateHourEvent, " +
                "@Local, @Address, @Price, @Status)";
            var parameters = new DynamicParameters(newCityEvent);

            using var conn = _cnnDataBase.CreateConnection();
            return conn.Execute(query, parameters) == 1;
        }

        public bool UpdateCityEvent(long idEvent, CityEvent cityEvent)
        {
            var query = "UPDATE CityEvent set Title = @Title, Description = @Description, DateHourEvent = @DateHourEvent, Local = @Local, Address = @Address, Price = @Price, Status = @Status WHERE IdEvent = @idEvent";
            var parameters = new DynamicParameters(cityEvent);
            cityEvent.IdEvent = idEvent;

            using var conn = _cnnDataBase.CreateConnection();
            return conn.Execute(query, parameters) == 1;
        }

        public bool DeleteCityEvent(long idEvent)
        {
            var query = "DELETE FROM CityEvent WHERE IdEvent = @idEvent";
            var parameters = new DynamicParameters(new
            {
                idEvent,
            });

            using var conn = _cnnDataBase.CreateConnection();
            return conn.Execute(query, parameters) == 1;
        }
    }
}
