using API_Events.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace API_Events.Infra.Data
{
    public class ConnectionDataBase : IConnectionDataBase
    {
        private readonly IConfiguration _configuration;
        public ConnectionDataBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

    }
}