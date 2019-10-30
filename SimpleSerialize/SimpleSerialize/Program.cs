using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace SimpleSerialize
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Object Serialization\n");

            var jbc = new JamesBondCar()
            {
                CanFly = true,
                CanSubmerge = false,
                TheRadio = new Radio()
                {
                    stationPresets = new[] { 89.3, 105.1, 97.1 },
                    hasTweeters = true
                }
            };

            //SaveAsBinaryFormat(jbc, "CarData.dat");
            //LoadFromBinaryFile("CarData.dat");
            //SaveAsSoapFormat(jbc, "CarData.dat");
            //LoadFromSoapFile("CarData.dat");
            SaveAsXmlFormat(jbc, "CarData.dat");
            Console.ReadLine();
        }

        private static void SaveAsBinaryFormat(object objGraph, string fileName)
        {
            var binFormat = new BinaryFormatter();
            using (var fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Saved car in binary format!");
        }

        private static void LoadFromBinaryFile(string fileName)
        {
            var binFormat = new BinaryFormatter();
            using (var fStream = File.OpenRead(fileName))
            {
                var carFromDisk = (JamesBondCar) binFormat.Deserialize(fStream);
                Console.WriteLine("Can this car fly? : {0}", carFromDisk.CanFly);
            }
        }

        private static void SaveAsSoapFormat(object objGraph, string fileName)
        {
            var soapFormat = new SoapFormatter();
            using (var fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Saved car in SOAP format!");
        }

        private static void LoadFromSoapFile(string fileName)
        {
            var soapFormat = new SoapFormatter();
            using (var fStream = File.OpenRead(fileName))
            {
                var carFromDisk = (JamesBondCar)soapFormat.Deserialize(fStream);
                Console.WriteLine("Can this car fly? : {0}", carFromDisk.CanFly);
            }
        }

        private static void SaveAsXmlFormat(object objGraph, string fileName)
        {
            var xmlFormat = new XmlSerializer(typeof(JamesBondCar));
            using (var fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine("=> Saved car in XML format!");
        }
    }

    [Serializable]
    public class Radio
    {
        public bool hasTweeters;
        public bool jasSubWoofers;
        public double[] stationPresets;

        [NonSerialized]
        public string radioId = "XF-552RR6";
    }

    [Serializable]
    public class Car
    {
        public Radio TheRadio = new Radio();
        public bool IsHatchBack;
    }
    [Serializable]
    public class JamesBondCar : Car
    {
        public bool CanFly;
        public bool CanSubmerge;
    }
}
