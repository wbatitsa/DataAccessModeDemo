using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDatabaseFirstWinDemo.Data
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly IConfiguration _configuration;

        //public SqlConnectionFactory(IConfiguration configuration)
        //{
        //    this._configuration = configuration;
        //}

        public SqlConnection GetNewSqlConnection()
        {
            return new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind");
        }
    }
}
