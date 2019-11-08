using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AutoLotDal.DisconnectedLayer
{
    public class InventoryDalDc
    {
        private readonly string _connectionString;
        private readonly SqlDataAdapter _adapter = null;

        public InventoryDalDc(string connectionString)
        {
            _connectionString = connectionString;
            ConfigureAdapter(out _adapter);
        }

        private void ConfigureAdapter(out SqlDataAdapter adapter)
        {
            adapter = new SqlDataAdapter("SELECT * FROM Inventory", _connectionString);
            var builder = new SqlCommandBuilder(adapter);
        }

        public DataTable GetAllInventory()
        {
            var inventory = new DataTable("Inventory");
            _adapter.Fill(inventory);
            return inventory;
        }

        public void UpdateInventory(DataTable modifiedTable)
        {
            _adapter.Update(modifiedTable);
        }

    }
}
