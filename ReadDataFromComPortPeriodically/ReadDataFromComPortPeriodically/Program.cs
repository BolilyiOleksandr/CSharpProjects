using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace ReadDataFromComPortPeriodically
{
    internal class Program
    {
        private static ComPortOperations _comPort = null;
        private static void Main(string[] args)
        {
            Console.WriteLine("Read Data From Com Port Periodically!\n\r");

            while (true)
            {
                _comPort = new ComPortOperations();
                _comPort.InitializeComPort("COM6", "9600");
                var data = _comPort.ReadDataFromComPort(10000);
                Console.WriteLine("Data: {0}", data);
                _comPort.CloseComPort();
            }
        }

        public static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Sending ping...");
        }
    }

    public class ComPortOperations
    {
        #region Variables

        private SerialPort _comPort = null;
        private string _buffer = "";

        #endregion

        /// <summary>
        /// The method that initializes the Com Port.
        /// <param name="comPortName">Com Port name value.</param>
        /// <param name="baudRate">Baud rate value.</param>
        /// </summary>
        public void InitializeComPort(string comPortName, string baudRate)
        {
            _comPort = new SerialPort()
            {
                PortName = comPortName,
                BaudRate = Convert.ToInt32(baudRate),
                Encoding = Encoding.ASCII,
                DataBits = 8,
                StopBits = StopBits.One,
                Parity = Parity.None,
                ReadBufferSize = 4096,
                NewLine = "\r\n",
                Handshake = Handshake.None,
                ReceivedBytesThreshold = 100000
            };
        }

        /// <summary>
        /// The method that reads the data from the Com Port.
        /// </summary>
        /// <param name="readTimeout">ReadTimeout value.</param>
        /// <returns></returns>
        public string ReadDataFromComPort(int readTimeout)
        {
            var dataFromComPort = "";
            if (_comPort != null)
            {
                if (!_comPort.IsOpen)
                {
                    _comPort.Open();
                    try
                    {
                        do
                        {
                            _comPort.ReadTimeout = readTimeout;
                            //_comPort.WriteLine("\r\n");
                            _comPort.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
                            dataFromComPort = _comPort.ReadLine();
                        } while (dataFromComPort.Length == 0);
                        _comPort.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Message: {ex.Message}");
                    }
                    finally
                    {
                        _comPort.Close();
                    }
                }
            }

            return dataFromComPort;
        }

        /// <summary>
        /// The method that receives the data during the reading process from the Com Port.
        /// </summary>
        /// <param name="sender">Object instance.</param>
        /// <param name="e">SerialDataReceiveEventArgs instance.</param>
        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            _buffer += _comPort.ReadExisting();
            if (_buffer.Contains("\r\n"))
            {
                var informationFromComPort = _comPort.ReadLine();
            }
        }

        /// <summary>
        /// The method that closes the Com Port.
        /// </summary>
        public void CloseComPort()
        {
            if (_comPort.IsOpen)
                _comPort.Close();
        }

    }
}
