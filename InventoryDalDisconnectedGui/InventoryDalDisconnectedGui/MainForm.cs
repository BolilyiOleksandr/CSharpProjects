using System;
using System.Data;
using System.Windows.Forms;
using AutoLotDal.DisconnectedLayer;

namespace InventoryDalDisconnectedGui
{
    public partial class MainForm : Form
    {
        private InventoryDalDc _dal = null;

        public MainForm()
        {
            InitializeComponent();

            const string connectionString =
                @"Data Source=SEGOTW10393726;Initial Catalog=AutoLot;Integrated Security=True;Pooling=False";
            _dal = new InventoryDalDc(connectionString);
            inventoryGrid.DataSource = _dal.GetAllInventory();
        }

        private void btnUpdateInventory_Click(object sender, EventArgs e)
        {
            var changedDataTable = (DataTable)inventoryGrid.DataSource;
            try
            {
                _dal.UpdateInventory(changedDataTable);
                inventoryGrid.DataSource = _dal.GetAllInventory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
