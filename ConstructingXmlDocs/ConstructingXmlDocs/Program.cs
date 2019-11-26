using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructingXmlDocs
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Constructing XML Docs *****\n");

            CreateFullXDocument();
            MakeXElementFromArray();
            ParseAndLoadExistingXml();

            Console.ReadLine();
        }

        private static void CreateFullXDocument()
        {
            var inventoryDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Current Inventory of cars!"),
                new XProcessingInstruction("xml-stylesheet", "href='MyStyles.css' title='Compact' type='text/css'"),
                new XElement("Inventory",
                    new XElement("Car", new XAttribute("Id", "1"),
                        new XElement("Color", "Green"),
                        new XElement("Make", "BMW"),
                        new XElement("PetName", "Stan")),
                        new XElement("Car", new XAttribute("Id", "2"),
                            new XElement("Color", "Pink"),
                            new XElement("Make", "Yugo"),
                            new XElement("PetName", "Melvin")
                        )));

            inventoryDoc.Save("SimpleInventory.xml");
        }

        private static void MakeXElementFromArray()
        {
            var people = new[]
            {
                new {FirstName = "Mandy", Age = 32},
                new {FirstName = "Andrew", Age = 40},
                new {FirstName = "Dave", Age = 41},
                new {FirstName = "Sara", Age = 31}
            };

            var peopleDoc = new XElement("People",
                from c in people
                select new XElement("Person", new XAttribute("Age", c.Age), new XElement("FirstName", c.FirstName)));

            Console.WriteLine(peopleDoc);
        }

        private static void ParseAndLoadExistingXml()
        {
            const string myElement = @"<Car Id = '3'>
                            <Color>Yellow</Color>
                            <Make>Yugo</Make>
                            </Car>";
            var newElement = XElement.Parse(myElement);
            Console.WriteLine(newElement);
            Console.WriteLine();

            var myDoc = XDocument.Load("SimpleInventory.xml");
            Console.WriteLine(myDoc);
        }

    }
}
