using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using AutoLotDal.Models;

namespace AutoLotDal.ConnectedLayer
{
    public class InventoryDal
    {
        private SqlConnection _sqlConnection = null;

        public void OpenConnection(string connectionString)
        {
            _sqlConnection = new SqlConnection
            {
                ConnectionString = connectionString
            };
            _sqlConnection.Open();
        }

        public void CloseConnection()
        {
            _sqlConnection.Close();
        }

        public void InsertAuto(int id, string color, string make, string petName)
        {
            const string sql = "INSERT INTO Inventory (Make, Color, PetName) VALUES (@Make, @Color, @PetName)";
            using (var command = new SqlCommand(sql, _sqlConnection))
            {
                var parameter = new SqlParameter
                {
                    ParameterName = "@Make",
                    Value = make,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Color",
                    Value = color,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@PetName",
                    Value = petName,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }
        }

        public void InsertAuto(NewCar car)
        {
            var sql = "INSERT INTO Inventory" + "(Make, Color, PetName) VALUES" + $"('{car.Make}','{car.Color}','{car.PetName}')";
            using (var command = new SqlCommand(sql, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCar(int id)
        {
            var sql = $"DELETE FROM Inventory WHERE CarId = '{id}'";
            using (var command = new SqlCommand(sql, _sqlConnection))
            {
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    var error = new Exception("Sorry! That car is on order!", ex);
                    throw error;
                }
            }
        }

        public void UpdateCarPetName(int id, string newPetName)
        {
            var sql = $"UPDATE Inventory SET PetName = '{newPetName}' WHERE CarId = '{id}'";
            using (var command = new SqlCommand(sql, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        public List<NewCar> GetAllInventoryAsList()
        {
            var inventory = new List<NewCar>();
            const string sql = "SELECT * FROM Inventory";

            using (var command = new SqlCommand(sql, _sqlConnection))
            {
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    inventory.Add(new NewCar
                    {
                        CarId = (int)dataReader["CarId"],
                        Color = (string)dataReader["Color"],
                        Make = (string)dataReader["Make"],
                        PetName = (string)dataReader["PetName"]
                    });
                }

                dataReader.Close();
            }

            return inventory;
        }

        public DataTable GetAllInventoryAsDataTable()
        {
            var dataTable = new DataTable();
            const string sql = "SELECT * FROM Inventory";

            using (var command = new SqlCommand(sql, _sqlConnection))
            {
                var dataReader = command.ExecuteReader();
                dataTable.Load(dataReader);
                dataReader.Close();
            }

            return dataTable;
        }

        public string LookUpPetName(int carId)
        {
            string carPetName;

            using (var command = new SqlCommand("GetPetName", _sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                var param = new SqlParameter
                {
                    ParameterName = "@carId",
                    SqlDbType = SqlDbType.Int,
                    Value = carId,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(param);

                param = new SqlParameter
                {
                    ParameterName = "@petName",
                    SqlDbType = SqlDbType.Char,
                    Size = 10,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(param);

                command.ExecuteNonQuery();
                carPetName = (string)command.Parameters["@petName"].Value;
            }

            return carPetName;
        }

        public void ProcessCreditRisk(bool throwEx, int custId)
        {
            string fName;
            string lName;
            var cmdSelect = new SqlCommand($"SELECT * FROM Customers WHERE CustId = {custId}", _sqlConnection);

            using (var dataReader = cmdSelect.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    fName = (string)dataReader["FirstName"];
                    lName = (string)dataReader["LastName"];
                }
                else
                {
                    return;
                }
            }

            var cmdRemove = new SqlCommand($"DELETE FROM Customers WHERE CustId = {custId}", _sqlConnection);
            var cmdInsert = new SqlCommand($"INSERT INTO CreditRisks(FirstName, LastName) VALUES('{fName}', '{lName}')",
                _sqlConnection);
            SqlTransaction transaction = null;

            try
            {
                transaction = _sqlConnection.BeginTransaction();
                cmdInsert.Transaction = transaction;
                cmdRemove.Transaction = transaction;

                cmdInsert.ExecuteNonQuery();
                cmdRemove.ExecuteNonQuery();

                if (throwEx)
                {
                    throw new Exception("Sorry! Database error! Transaction failed...");
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction?.Rollback();
            }
        }

    }
}
