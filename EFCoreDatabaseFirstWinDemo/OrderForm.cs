using EFCoreDatabaseFirstWinDemo.Data;
using EFCoreDatabaseFirstWinDemo.Models;
using EFCoreDatabaseFirstWinDemo.Services;
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
        private readonly IOrderService _orderService;
        BindingList<OrderDetailViewModel> _orderDetails = new BindingList<OrderDetailViewModel>();

        public OrderForm(NorthwindDbConext northwindDbConext, IOrderService orderService)
        {
            InitializeComponent();

            detailsDataGridView.AutoGenerateColumns = false;
            this.northwindDbConext = northwindDbConext;
            this._orderService = orderService;
            Load += OrderForm_Load;


        }

        private void OrderForm_Load(object? sender, EventArgs e)
        {
            employeeComboBox.DataSource = northwindDbConext.Employees.ToList();
            employeeComboBox.DisplayMember = nameof(Employee.FirstName);
            employeeComboBox.ValueMember = nameof(Employee.EmployeeId);

            customerComboBox.DataSource = northwindDbConext.Customers.ToList();
            customerComboBox.DisplayMember = nameof(Customer.CompanyName);
            customerComboBox.ValueMember = nameof(Customer.CustomerId);

            detailsDataGridView.DataSource = _orderDetails;

            //var order = northwindDbConext.Orders
            //    .Include(a => a.Employee)
            //    .Include(a => a.Customer)
            //    .Include(a => a.OrderDetails).ThenInclude(a => a.Product)
            //    .Where(a => a.OrderId == 10248)
            //    .FirstOrDefault();

            //employeeComboBox.SelectedValue = order.EmployeeId;
            //customerComboBox.SelectedValue = order.CustomerId;
            //detailsDataGridView.DataSource = order.OrderDetails.Select(a => new OrderDetailViewModel(a)).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Fill Order
            var order = new Order();
            order.EmployeeId = int.Parse(employeeComboBox.SelectedValue.ToString());
            order.CustomerId = customerComboBox.SelectedValue.ToString();
            order.OrderDate = DateTime.Now;
            order.RequiredDate = DateTime.Now.AddDays(30);
            order.OrderDetails = new List<OrderDetail>();

            // Add Details
            foreach (var item in _orderDetails)
            {

                order.OrderDetails.Add(item.OrderDetail);
            }
                
            _orderService.SaveOrder(order);

            MessageBox.Show("Order saved!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var products = northwindDbConext.Products.ToList();
            var random = new Random();
            var product = products[random.Next(0, products.Count - 1)];
            _orderDetails.Add(new OrderDetailViewModel(new OrderDetail(){
                Product = product ,
                Quantity = (short)random.Next(1, 255),
                UnitPrice = product.UnitPrice.Value
            }));

        }
    }

    public class OrderDetailViewModel
    {
        private readonly OrderDetail _orderDetail;

        public int ProductId => OrderDetail.ProductId;
        public string ProductName => OrderDetail.Product.ProductName;
        public decimal UnitPrice => OrderDetail.UnitPrice;
        public short Quantity => OrderDetail.Quantity;

        public OrderDetail OrderDetail => _orderDetail;

        public OrderDetailViewModel(OrderDetail orderDetail)
        {
            this._orderDetail = orderDetail;
        }



    }

}
