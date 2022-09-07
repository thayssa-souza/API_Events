using System.Data;

namespace API_Events.Core.Interfaces
{
    public interface IConnectionDataBase
    {
        IDbConnection CreateConnection();
    }
}
