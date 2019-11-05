using System;
using AutoLotDal.ConnectedLayer;

namespace AdoNetTransaction
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("**** Simple Transaction Example *****\n");

            var throwEx = true;

            Console.Write("Do you want to throw an exception (Y or N): ");
            var userAnswer = Console.ReadLine();
            if (userAnswer?.ToLower() == "n")
            {
                throwEx = false;
            }

            var inventory = new InventoryDal();
            inventory.OpenConnection(@"Data Source=SEGOTW10393726;Initial Catalog=AutoLot;Integrated Security=SSPI");
            inventory.ProcessCreditRisk(throwEx, 7);
            Console.WriteLine("Check CreditRisk table for results");
            Console.ReadLine();
        }
    }
}
