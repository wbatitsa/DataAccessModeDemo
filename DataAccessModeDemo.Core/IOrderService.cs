using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessModeDemo.Core
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetOrders();
    }

    // Data Transfer Object
    public class OrderDto
    {
        public int OrderID { get; set; }

        public string CustomerID { get; set; }

        public string CustomerName { get; set; }

        //public int? EmployeeID { get; set; }

        public string EmployeeName { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }
    }

}
