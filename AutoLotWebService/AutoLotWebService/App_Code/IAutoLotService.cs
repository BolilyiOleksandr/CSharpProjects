using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

[ServiceContract]
public interface IAutoLotService
{
    [OperationContract]
    void InsertCar(int id, string make, string color, string petName);

    [OperationContract(Name = "InsertCarWithDetails")]
    void InsertCar(InventoryRecord car);

    [OperationContract]
    InventoryRecord[] GetInventory();
}

[DataContract]
public class InventoryRecord
{
    [DataMember] public int Id;
    [DataMember] public string Make;
    [DataMember] public string Color;
    [DataMember] public string PetName;
}
