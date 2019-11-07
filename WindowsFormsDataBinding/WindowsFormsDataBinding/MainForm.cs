using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsDataBinding
{
    public partial class MainForm : Form
    {
        private List<Car> _listCars = null;
        private DataTable _inventoryTable = new DataTable();
        private DataView _yugosOnlyView = null;
        public MainForm()
        {
            InitializeComponent();

            _listCars = new List<Car>
            {
                new Car {Id = 1, PetName = "Chucky", Make = "BMW", Color = "Green"},
                new Car {Id = 2, PetName = "Tiny", Make = "Yugo", Color = "White"},
                new Car {Id = 3, PetName = "Ami", Make = "Jeep", Color = "Tan"},
                new Car {Id = 4, PetName = "Pain Inducer", Make = "Caravan", Color = "Pink"},
                new Car {Id = 5, PetName = "Fred", Make = "BMW", Color = "Green"},
                new Car {Id = 6, PetName = "Sidd", Make = "BMW", Color = "Black"},
                new Car {Id = 7, PetName = "Mel", Make = "Firebird", Color = "Red"},
                new Car {Id = 8, PetName = "Sarah", Make = "Colt", Color = "Black"}
            };

            CreateDataTable();
            CreateDataView();
        }

        private void CreateDataTable()
        {
            var carIdColumn = new DataColumn("Id", typeof(int));
            var carMakeColumn = new DataColumn("Make", typeof(string));
            var carColorColumn = new DataColumn("Color", typeof(string));
            var carPetNameColumn = new DataColumn("PetName", typeof(string))
            {
                Caption = "Pet Name"
            };

            _inventoryTable.Columns.AddRange(new[] { carIdColumn, carMakeColumn, carColorColumn, carPetNameColumn });

            foreach (var c in _listCars)
            {
                var newRow = _inventoryTable.NewRow();
                newRow["Id"] = c.Id;
                newRow["Make"] = c.Make;
                newRow["Color"] = c.Color;
                newRow["PetName"] = c.PetName;

                _inventoryTable.Rows.Add(newRow);
            }

            carInventoryGridView.DataSource = _inventoryTable;
        }

        private void CreateDataView()
        {
            _yugosOnlyView = new DataView(_inventoryTable)
            {
                RowFilter = "Make='Yugo'"
            };
            dataGridYugosView.DataSource = _yugosOnlyView;
        }

        private void btnRemoveCar_Click(object sender, EventArgs e)
        {
            try
            {
                var rowToDelete = _inventoryTable.Select($"Id={int.Parse(txtCarToRemove.Text)}");
                rowToDelete[0].Delete();
                _inventoryTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txtCarToRemove.Text = "";
            }
        }

        private void btnDisplayMakes_Click(object sender, EventArgs e)
        {
            var filterStr = $"Make='{txtMakeToView.Text}'";
            var makes = _inventoryTable.Select(filterStr);

            if (makes.Length == 0)
                MessageBox.Show("Sorry, no cars...", "Selection error!");
            else
            {
                string strMake = null;
                for (var i = 0; i < makes.Length; i++)
                {
                    strMake += makes[i]["PetName"] + "\n";
                }

                MessageBox.Show(strMake, $"We have {txtMakeToView.Text}s named:");
            }

            txtMakeToView.Text = "";
        }

        private void btnChangeMakes_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != MessageBox.Show("Are you sure?? BMWs are much nicer that Yugos!", "Please confirm!",
                    MessageBoxButtons.YesNo))
                return;

            const string filterStr = "Make='BMW'";
            var makes = _inventoryTable.Select(filterStr);
            for (var i = 0; i < makes.Length; i++)
            {
                makes[i]["Make"] = "Yugo";
            }
        }

        private void ShowCarsWithIdGreaterThanFive()
        {
            const string newFilterStr = "Id > 5";
            var properIds = _inventoryTable.Select(newFilterStr);
            string strIds = null;
            for (var i = 0; i < properIds.Length; i++)
            {
                var temp = properIds[i];
                strIds += $"{temp["PetName"]} is Id {temp["Id"]}\n";
            }

            MessageBox.Show(strIds, "Pet names of cars where Id > 5");
        }


    }
}
