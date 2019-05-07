using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        #region Variables
        private const string TxtFilePath = @"C:\Users\JA0006284\Desktop\ConsoleApp\ConsoleApp\InputData.txt";
        private const string XmlFilePath = @"C:\Users\JA0006284\Desktop\ConsoleApp\ConsoleApp\InputData.xml";
        #endregion
        static void Main(string[] args)
        {
            //ReadDataFromTxtFile(TxtFilePath);
            //ReadDataFromXmlFile(XmlFilePath);

            var txtResult = Task.Run(() => ReadDataFromTxtFile(TxtFilePath));
            var xmlResult = Task.Run(() => ReadDataFromXmlFile(XmlFilePath));

            Task.WaitAll(txtResult, xmlResult);

            var txt = txtResult.Result;
            var xml = xmlResult.Result;

            var result = new List<Trade>();
            result.AddRange(txt);
            result.AddRange(xml);

            var tradeTypeValue = from item in result
                                 orderby item.Value descending
                                 //group item.Value by item.Type into items
                                 select new { item.Type, item.Value };

            //var results = from p in persons
            //    group p.car by p.PersonId into g
            //    select new { PersonId = g.Key, Cars = g.ToList() };

            foreach (var item in tradeTypeValue)
            {
                Console.WriteLine(item);
            }
            

        }

        private static List<Trade> ReadDataFromTxtFile(string txtFilePath)
        {
            var trade = new List<Trade>();
            var result = File.ReadAllLines(txtFilePath);
            foreach (var s in result)
            {
                var symbol = s.Split(',');
                trade.Add(new Trade()
                {
                    Id = symbol[0],
                    Type = symbol[1],
                    Date = Convert.ToDateTime(symbol[2]),
                    Value = Convert.ToDecimal(symbol[3])
                });
            }

            return trade;
        }

        private static List<Trade> ReadDataFromXmlFile(string xmlFilePath)
        {
            var trade = new List<Trade>();
            var document = new XmlDocument();
            document.Load(xmlFilePath);
            if (document.DocumentElement != null)
            {
                foreach (XmlNode node in document.DocumentElement.ChildNodes)
                {
                    if (node["Id"] != null && node["Type"] != null && node["Date"] != null && node["Value"] != null)
                        trade.Add(new Trade()
                        {
                            Id = node["Id"].InnerText,
                            Type = node["Type"].InnerText,
                            Date = Convert.ToDateTime(node["Date"].InnerText),
                            Value = Convert.ToDecimal(node["Value"].InnerText)
                        });
                }
            }

            return trade;
        }
    }

    class Trade
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
    }

}
