using Dapper;
using DataAccessModeDemo.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessModeDemo.AdoNet
{
    // Micro ORMs
    public class DapperOrderService : IOrderService
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public DapperOrderService(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<OrderDto> GetOrders()
        {
            var connection = _connectionFactory.GetNewConnection();
            var orders = connection.Query<OrderDto>("GetOrderDetails", 
                commandType: System.Data.CommandType.StoredProcedure);
            return orders;
        }
    }


}
