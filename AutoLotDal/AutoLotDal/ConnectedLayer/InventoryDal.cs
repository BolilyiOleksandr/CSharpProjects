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

    }
}
