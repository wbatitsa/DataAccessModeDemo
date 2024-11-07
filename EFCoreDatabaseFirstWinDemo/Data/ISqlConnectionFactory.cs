using Microsoft.Data.SqlClient;

namespace EFCoreDatabaseFirstWinDemo.Data
{
    public interface ISqlConnectionFactory
    {
        SqlConnection GetNewSqlConnection();
    }
}