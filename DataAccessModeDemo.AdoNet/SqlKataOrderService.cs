using DataAccessModeDemo.Core;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace DataAccessModeDemo.AdoNet
{
    // Query Builder
    public class SqlKataOrderService : IOrderService
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public SqlKataOrderService(IDbConnectionFactory dbConnectionFactory)
        {
            this._dbConnectionFactory = dbConnectionFactory;
        }

        public IEnumerable<OrderDto> GetOrders()
        {
            var connection = _dbConnectionFactory.GetNewConnection();
            var db = new QueryFactory(connection, new SqlServerCompiler());

            var query = db.Query("Orders as o" )
                .Select("o.OrderID", "o.CustomerID",
                        "c.CompanyName as CustomerName",
                        "o.OrderDate", "o.RequiredDate", "o.ShippedDate")
                .SelectRaw("CONCAT(e.FirstName, ' ', e.LastName) as EmployeeName")
                .LeftJoin("Customers as c", "o.CustomerID", "c.CustomerID")
                .LeftJoin("Employees as e", "o.EmployeeID", "e.EmployeeID");

            var result = db.Get<OrderDto>(query);

            return result.ToList();
        }
    }


}
