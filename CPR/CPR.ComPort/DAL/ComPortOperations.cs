using System;
using System.IO.Ports;
using System.Text;

namespace CPR.ComPort.DAL
{
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
                    try
                    {
                        do
                        {
                            _comPort.Open();
                            _comPort.ReadTimeout = readTimeout;
                            _comPort.WriteLine("\r\n");
                            _comPort.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
                            dataFromComPort = _comPort.ReadLine();
                            _comPort.Close();
                        } while (dataFromComPort.Length == 0);
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
    }
}