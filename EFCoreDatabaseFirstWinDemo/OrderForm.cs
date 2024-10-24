using EFCoreDatabaseFirstWinDemo.Data;
using EFCoreDatabaseFirstWinDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFCoreDatabaseFirstWinDemo
{
    public partial class OrderForm : Form
    {
        private readonly NorthwindDbConext northwindDbConext;

        public OrderForm(NorthwindDbConext northwindDbConext)
        {
            InitializeComponent();

            detailsDataGridView.AutoGenerateColumns = false;
            this.northwindDbConext = northwindDbConext;
            Load += OrderForm_Load;
        }

        private void OrderForm_Load(object? sender, EventArgs e)
        {

            employeeComboBox.DataSource = northwindDbConext.Employees.ToList();
            employeeComboBox.DisplayMember = nameof(Employee.FirstName);
            employeeComboBox.ValueMember= nameof(Employee.EmployeeId);

            customerComboBox.DataSource = northwindDbConext.Customers.ToList();
            customerComboBox.DisplayMember = nameof(Customer.CompanyName);
            customerComboBox.ValueMember = nameof(Customer.CustomerId);

            var order = northwindDbConext.Orders
                .Include(a=> a.Employee)
                .Include(a=> a.Customer)
                .Include(a=> a.OrderDetails).ThenInclude(a=> a.Product)
                .Where(a=> a.OrderId == 10248)
                .FirstOrDefault();

            employeeComboBox.SelectedValue = order.EmployeeId;
            customerComboBox.SelectedValue = order.CustomerId;  
            detailsDataGridView.DataSource = order.OrderDetails.Select(a=> new OrderDetailViewModel(a)).ToList();
        }

       

    }

    public class OrderDetailViewModel
    {
        private readonly OrderDetail _orderDetail;

        public string ProductName => _orderDetail.Product.ProductName;
        public decimal UnitPrice => _orderDetail.UnitPrice;
        public short Quantity => _orderDetail.Quantity;

        public OrderDetailViewModel(OrderDetail orderDetail)
        {
            this._orderDetail = orderDetail;
        }
    }

}
