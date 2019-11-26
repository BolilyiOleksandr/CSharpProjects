using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LinqToXmlFirstLook
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            BuildXmlDocWithDom();
        }

        private static void BuildXmlDocWithDom()
        {
            var doc = new XmlDocument();
            var inventory = doc.CreateElement("Inventory");

            var car = doc.CreateElement("Car");
            car.SetAttribute("Id", "1000");

            var name = doc.CreateElement("PetName");
            name.InnerText = "Jimbo";

            var color = doc.CreateElement("Color");
            color.InnerText = "Red";

            var make = doc.CreateElement("Make");
            make.InnerText = "Ford";

            car.AppendChild(name);
            car.AppendChild(color);
            car.AppendChild(make);
            inventory.AppendChild(car);
            doc.AppendChild(inventory);
            doc.Save("Inventory.xml");
        }

    }
}
