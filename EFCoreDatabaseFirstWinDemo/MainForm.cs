using EFCoreDatabaseFirstWinDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDatabaseFirstWinDemo
{
    public partial class MainForm : Form
    {
        private readonly NorthwindDbConext _northwindDbConext;

        public MainForm(NorthwindDbConext northwindDbConext)
        {
            InitializeComponent();
            this._northwindDbConext = northwindDbConext;
            Load += MainForm_Load;
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            dataGridView1.DataSource = _northwindDbConext.Products
                .Include(a=> a.Category)
                .Include(a=> a.Supplier)
                .Select(a=> new ProductListItemViewModel
                { 
                    ProductId = a.ProductId,
                    ProductName = a.ProductName,
                    CategoryName = a.Category.CategoryName,
                    CompanyName = a.Supplier.CompanyName
                })
                .ToList();
        }
    }


    class ProductListItemViewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string CategoryName { get; set; }

        public string CompanyName { get; set; }
    }
}
