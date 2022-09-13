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

        public List<CityEvent> GetCityEvents()
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

        public bool InsertCityEvent(CityEvent newCityEvent)
        {
            var query = "INSERT INTO CityEvent VALUES (@Title, @Description, @DateHourEvent, " +
                "@Local, @Address, @Price, @Status)";
            var parameters = new DynamicParameters(newCityEvent);

            using var conn = _cnnDataBase.CreateConnection();
            return conn.Execute(query, parameters) == 1;
        }

        public bool UpdateCityEvent(long id, CityEvent cityEvent)
        {
            var query = "UPDATE CityEvent set Title = @Title, Description = @Description, DateHourEvent = @DateHourEvent" +
                "Local = @Local, Address = @Adress, Price = @Price, Status = @Status";
            var parameters = new DynamicParameters(cityEvent);
            cityEvent.IdEvent = id;

            using var conn = _cnnDataBase.CreateConnection();
            return conn.Execute(query, parameters) == 1;
        }
    }
}
