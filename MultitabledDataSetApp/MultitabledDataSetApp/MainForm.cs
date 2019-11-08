using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MultitabledDataSetApp
{
    public partial class MainForm : Form
    {
        private readonly DataSet _autoLotDs = new DataSet("AutoLot");
        private SqlCommandBuilder _sqlCbInventory;
        private SqlCommandBuilder _sqlCbCustomers;
        private SqlCommandBuilder _sqlCbOrders;
        private SqlDataAdapter _inventoryTableAdapter;
        private SqlDataAdapter _customerTableAdapter;
        private SqlDataAdapter _ordersTableAdapter;
        private string _connectionString;
        public MainForm()
        {
            InitializeComponent();

            _connectionString = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            _inventoryTableAdapter = new SqlDataAdapter("SELECT * FROM Inventory", _connectionString);
            _customerTableAdapter = new SqlDataAdapter("SELECT * FROM Customers", _connectionString);
            _ordersTableAdapter = new SqlDataAdapter("SELECT * FROM Orders", _connectionString);

            _sqlCbInventory = new SqlCommandBuilder(_inventoryTableAdapter);
            _sqlCbCustomers = new SqlCommandBuilder(_customerTableAdapter);
            _sqlCbOrders = new SqlCommandBuilder(_ordersTableAdapter);

            _inventoryTableAdapter.Fill(_autoLotDs, "Inventory");
            _customerTableAdapter.Fill(_autoLotDs, "Customers");
            _ordersTableAdapter.Fill(_autoLotDs, "Orders");

            BuildTableRelationship();

            dataGridViewInventory.DataSource = _autoLotDs.Tables["Inventory"];
            dataGridViewCustomers.DataSource = _autoLotDs.Tables["Customers"];
            dataGridViewOrders.DataSource = _autoLotDs.Tables["Orders"];
        }

        private void BuildTableRelationship()
        {
            var dataRelation = new DataRelation("CustomerOrder", _autoLotDs.Tables["Customers"].Columns["CustId"],
                _autoLotDs.Tables["Orders"].Columns["CustId"]);
            _autoLotDs.Relations.Add(dataRelation);

            dataRelation = new DataRelation("InventoryOrder", _autoLotDs.Tables["Inventory"].Columns["CarId"],
                _autoLotDs.Tables["Orders"].Columns["CarId"]);
            _autoLotDs.Relations.Add(dataRelation);
        }

        private void btnUpdateDatabase_Click(object sender, System.EventArgs e)
        {
            try
            {
                _inventoryTableAdapter.Update(_autoLotDs, "Inventory");
                _customerTableAdapter.Update(_autoLotDs, "Customers");
                _ordersTableAdapter.Update(_autoLotDs, "Orders");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetOrderInfo_Click(object sender, EventArgs e)
        {
            var strOrderInfo = string.Empty;
            var custId = int.Parse(txtCustId.Text);
            var drsCust = _autoLotDs.Tables["Customers"].Select($"CustId={custId}");
            strOrderInfo += $"Customer {drsCust[0]["CustID"]}: {drsCust[0]["FirstName"].ToString().Trim()} {drsCust[0]["LastName"].ToString().Trim()}\n";
            var drsOrder = drsCust[0].GetChildRows(_autoLotDs.Relations["CustomerOrder"]);
            
            foreach (var order in drsOrder)
            {
                strOrderInfo += $"----\nOrder Number:{ order["OrderID"]}\n";
                var drsInv = order.GetParentRows(_autoLotDs.Relations["InventoryOrder"]);
                var car = drsInv[0];
                strOrderInfo += $"Make: {car["Make"]}\n";
                strOrderInfo += $"Color: {car["Color"]}\n";
                strOrderInfo += $"Pet Name: {car["PetName"]}\n";
            }
            MessageBox.Show(strOrderInfo, "Order Details");
        }
    }
}
