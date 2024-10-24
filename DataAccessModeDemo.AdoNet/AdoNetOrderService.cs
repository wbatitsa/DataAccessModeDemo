using DataAccessModeDemo.Core;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Reflection.PortableExecutable;

namespace DataAccessModeDemo.AdoNet
{

    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection GetNewConnection()
        {
            var connectionString = _configuration.GetConnectionString("NorthwindConnectionString");
            var connection = new SqlConnection(connectionString);
            return connection;
        }
    }

    public class AdoNetOrderService : IOrderService
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public AdoNetOrderService(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<OrderDto> GetOrders()
        {
            var connection = _connectionFactory.GetNewConnection();
            var command = connection.CreateCommand();
            command.CommandText = "GetOrderDetails";
            command.CommandType = System.Data.CommandType.StoredProcedure;

            connection.Open();

            var orders = new List<OrderDto>();
            var dataReader = command.ExecuteReader();
            
            // Object Realtional Mapper

            // Mapping
            while (dataReader.Read())
            {
                var newOrder = new OrderDto();
                newOrder.OrderID = (int)dataReader["OrderID"];
                if (dataReader["CustomerID"] != DBNull.Value)
                {
                    newOrder.CustomerID = (string)dataReader["CustomerID"];
                }

                if (dataReader["CustomerName"] != DBNull.Value)
                {
                    newOrder.CustomerName = (string)dataReader["CustomerName"];
                }

                //if (dataReader["EmployeeID"] != DBNull.Value)
                //{
                //    newOrder.EmployeeID = (int?)dataReader["EmployeeID"];
                //}

                if (dataReader["EmployeeName"] != DBNull.Value)
                {
                    newOrder.EmployeeName = (string)dataReader["EmployeeName"];
                }

                if (dataReader["OrderDate"] != DBNull.Value)
                {
                    newOrder.OrderDate = (DateTime?)dataReader["OrderDate"];
                }

                if (dataReader["RequiredDate"] != DBNull.Value)
                {
                    newOrder.RequiredDate = (DateTime?)dataReader["RequiredDate"];
                }

                if (dataReader["ShippedDate"] != DBNull.Value)
                {
                    newOrder.ShippedDate = (DateTime?)dataReader["ShippedDate"];
                }

                orders.Add(newOrder);
            }

            connection.Close();

            return orders;
        }
    }
}
