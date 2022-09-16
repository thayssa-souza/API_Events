using API_Events.Core.Interfaces;
using API_Events.Core.Interfaces.IRepository;
using API_Events.Core.Models;
using Dapper;
using System;
using System.Diagnostics;

namespace API_Events.Infra.Data.Repositories
{
    public class CityEventRepository : ICityEventRepository
    {
        private readonly IConnectionDataBase _cnnDataBase;

        public CityEventRepository(IConnectionDataBase cnnDataBase)
        {
            _cnnDataBase = cnnDataBase;
        }

        public async Task<List<CityEvent>> GetAllEvents()
        {
            var query = "SELECT * FROM CityEvent";
            using var conn = _cnnDataBase.CreateConnection();
            return (await conn.QueryAsync<CityEvent>(query)).ToList();
        }

        public async Task<CityEvent> GetEventById(long idEvent)
        {
            var query = "SELECT * FROM CityEvent WHERE IdEvent = @idEvent";
            var parameters = new DynamicParameters(new { idEvent, });

            using var conn = _cnnDataBase.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<CityEvent>(query, parameters);
        }

        public async Task<List<CityEvent>> GetEventByTitle(string title)
        {
            var query = $"SELECT * FROM CityEvent WHERE title LIKE ('%' + @title + '%')";
            var parameters = new DynamicParameters(new { title, });

            using var conn = _cnnDataBase.CreateConnection();
            return  (await conn.QueryAsync<CityEvent>(query, parameters)).ToList();
        }

        public async Task<List<CityEvent>> GetEventByLocalDate(string local, DateTime dateHourEvent)
        {
            var query = $"SELECT * FROM CityEvent WHERE local LIKE ('%' + @local + '%') AND CONVERT (DATE, DateHourEvent) = @dateHourEvent";
            var parameters = new DynamicParameters(new
            {
                Local = local,
                DateHourEvent = dateHourEvent,
            });

            using var conn = _cnnDataBase.CreateConnection();
            return (await conn.QueryAsync<CityEvent>(query, parameters)).ToList();
        }

        public async Task<List<CityEvent>> GetEventByPriceDate(decimal priceMin, decimal priceMax, DateTime dateHourEvent)
        {
            var query = $"SELECT * FROM CityEvent WHERE price BETWEEN @priceMin AND @priceMax AND CONVERT (DATE, DateHourEvent) = @dateHourEvent";
            var parameters = new DynamicParameters(new
            {
                priceMin,
                priceMax,
                dateHourEvent,
            });

            using var conn = _cnnDataBase.CreateConnection();
            return (await conn.QueryAsync<CityEvent>(query, parameters)).ToList();
        }

        public async Task<CityEvent> ConsultReservation(long idEvent)
        {
            var query = $"SELECT * FROM EventReservation AS event " +
                $"INNER JOIN CityEvent AS city ON event.IdEvent = @idEvent AND city.IdEvent = @idEvent " +
                $"WHERE event.IdEvent = city.IdEvent"; ;
            var parameters = new DynamicParameters(new { idEvent });

            using var conn = _cnnDataBase.CreateConnection();
            return await conn.QueryFirstOrDefaultAsync<CityEvent>(query, parameters);
        }


        public async Task<bool> InsertCityEvent(CityEvent newCityEvent)
        {
            var query = "INSERT INTO CityEvent VALUES (@Title, @Description, @DateHourEvent, " +
                "@Local, @Address, @Price, @Status)";
            var parameters = new DynamicParameters(newCityEvent);

            using var conn = _cnnDataBase.CreateConnection();
            return await conn.ExecuteAsync(query, parameters) == 1;
        }

        public async Task<bool> UpdateCityEvent(long idEvent, CityEvent cityEvent)
        {
            var query = "UPDATE CityEvent set Title = @Title, Description = @Description, DateHourEvent = @DateHourEvent, Local = @Local, Address = @Address, Price = @Price, Status = @Status WHERE IdEvent = @idEvent";
            var parameters = new DynamicParameters(cityEvent);
            cityEvent.IdEvent = idEvent;

            using var conn = _cnnDataBase.CreateConnection();
            return await conn.ExecuteAsync(query, parameters) == 1;
        }

        public async Task<bool> InactiveCityEvent (long idEvent)
        {
            var query = "UPDATE CityEvent SET Status = 0 WHERE IdEvent = @IdEvent";
            var parameters = new DynamicParameters(new { idEvent });

            using var conn = _cnnDataBase.CreateConnection();
            return await conn.ExecuteAsync(query, parameters) == 1;
        }

        public async Task<bool> ActiveCityEvent (long idEvent)
        {
            var query = "UPDATE CityEvent SET Status = 1 WHERE IdEvent = @IdEvent";
            var parameters = new DynamicParameters(new { idEvent });

            using var conn = _cnnDataBase.CreateConnection();
            return await conn.ExecuteAsync(query, parameters) == 1;
        }

        public async Task<bool> DeleteCityEvent(long idEvent)
        {
            var query = "DELETE FROM CityEvent WHERE IdEvent = @idEvent";
            var parameters = new DynamicParameters(new { idEvent, });

            using var conn = _cnnDataBase.CreateConnection();
            return await conn.ExecuteAsync(query, parameters) == 1;
        }
    }
}
