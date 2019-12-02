using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AutoLotDal.ConnectedLayer;
using System.Data;

public class AutoLotService : IAutoLotService
{
    private const string ConnString = @"Data Source=SEGOTW10393726;Initial Catalog=AutoLot;Integrated Security=True";
    public InventoryRecord[] GetInventory()
    {
        var d = new InventoryDal();
        d.OpenConnection(ConnString);
        var dt = d.GetAllInventoryAsDataTable();
        d.CloseConnection();

        var records = new List<InventoryRecord>();
        var reader = dt.CreateDataReader();
        while (reader.Read())
        {
            var r = new InventoryRecord()
            {
                Id = (int)reader["CarId"],
                Color = ((string)reader["Color"]),
                Make = ((string)reader["Make"]),
                PetName = ((string)reader["PetName"])
            };
            records.Add(r);
        }

        return records.ToArray();
    }

    public void InsertCar(int id, string make, string color, string petName)
    {
        var d = new InventoryDal();
        d.OpenConnection(ConnString);
        d.InsertAuto(id, color, make, petName);
        d.CloseConnection();
    }

    public void InsertCar(InventoryRecord car)
    {
        var d = new InventoryDal();
        d.OpenConnection(ConnString);
        d.InsertAuto(car.Id, car.Color, car.Make, car.PetName);
        d.CloseConnection();
    }
}
