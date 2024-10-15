using Microsoft.Data.SqlClient;

namespace DataAccessModeDemo.AdoNet
{
    public interface IDbConnectionFactory
    {
        SqlConnection GetNewConnection();
    }
}