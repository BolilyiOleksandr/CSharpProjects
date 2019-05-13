using System;
using System.Reflection;
using System.Configuration;

namespace CPR.Reader.DAL
{
    internal class ReaderOperations
    {
        /// <summary>
        /// The method that reads the data from the Com Port using an external DLL file.
        /// </summary>
        /// <param name="pathToDllFile">Path to Dll file.</param>
        /// <returns></returns>
        public string ReadDataFromComPortUsingDllFile(string pathToDllFile)
        {
            var result = "";
            try
            {
                var assembly = Assembly.LoadFile(pathToDllFile);
                var type = assembly.GetType("CPR.ComPort.DAL.ComPortOperations");
                var comPortOperations = Activator.CreateInstance(type);

                var comPortMethod = type.GetMethod("InitializeComPort");
                if (comPortMethod != null)
                    comPortMethod.Invoke(comPortOperations, new object[] { ConfigurationManager.AppSettings["ComPort"], ConfigurationManager.AppSettings["BaudRate"] });

                var dataFromComPortMethod = type.GetMethod("ReadDataFromComPort");
                if (dataFromComPortMethod != null)
                    result = dataFromComPortMethod.Invoke(comPortOperations, new object[] { Convert.ToInt32(ConfigurationManager.AppSettings["ReadTimeOut"]) }).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}");
            }

            return result;
        }

    }
}
