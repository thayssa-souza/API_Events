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

        public CityEvent GetSpecificEvent(long id)
        {
            var query = "SELECT * FROM CityEvent WHERE id = @id";
            var parameters = new DynamicParameters(new
            {
                id,
            });
            using var conn = _cnnDataBase.CreateConnection();
            return conn.QueryFirstOrDefault<CityEvent>(query, parameters);
        }
    }
}
