using System;
using System.Configuration;
using CPR.Reader.DAL;

namespace CPR.Reader
{
    internal class Program
    {
        #region Variables
        private static readonly string PathToDllFile = ConfigurationManager.AppSettings["PathToDllFile"];
        private static ReaderOperations _reader = null;
        #endregion

        /// <summary>
        /// The entry point of the application.
        /// </summary>
        /// <param name="args">Args value.</param>
        private static void Main(string[] args)
        {
            Console.WriteLine("Please, put your Badge on Card Reader!");

            _reader = new ReaderOperations();
            var data = _reader.ReadDataFromComPortUsingDllFile(PathToDllFile);

            Console.WriteLine($"Data from Com Port: {data}");

            Console.ReadLine();
        }
    }

}
