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
            var sql = "INSERT INTO Inventory" + $"(Make, Color, PetName) VALUES ('{make}', '{color}', '{petName}')";
            using (var command = new SqlCommand(sql, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void InsertAuto(NewCar car)
        {
            var sql = "INSERT INTO Inventory" + "(Make, Color, PetName) VALUES" + $"('{car.Make}', '{car.Color}', '{car.PetName}')";
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

    }
}
