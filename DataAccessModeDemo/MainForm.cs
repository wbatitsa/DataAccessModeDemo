using DataAccessModeDemo.Core;

namespace DataAccessModeDemo
{
    public partial class MainForm : Form
    {
        private readonly IOrderService _orderService;

        public MainForm(IOrderService orderService )
        {
            InitializeComponent();
            _orderService = orderService;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ordersDataGridView.DataSource = _orderService.GetOrders();
        }
    }
}
