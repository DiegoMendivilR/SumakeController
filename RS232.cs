using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CESATAutomationDevelop
{
    public class RS232 : SerialPort
    {
        #region PROPERTIES
        public event EventHandler RS232DataReceived;
        #endregion

        #region CONSTRUCTORS
        public RS232(string portName)
        {
            PortName = portName;
            BaudRate = int.Parse("115200");
            DataBits = int.Parse("8");
            StopBits = (StopBits)Enum.Parse(typeof(StopBits), "1");
            Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            DataReceived += SerialDataReceived;
            bool connected = Connect();
        }
        public RS232(string portName, string baudRate, string dataBits, string stopBits, string parity)
        {
            PortName = portName;
            BaudRate = int.Parse(baudRate);
            DataBits = int.Parse(dataBits);
            StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits);
            Parity = (Parity)Enum.Parse(typeof(Parity), parity);
            DataReceived += SerialDataReceived;
            bool connected = Connect();
        }
        #endregion

        #region METHODS
        public bool Connect()
        {
            if (IsOpen) Close();
            else
                Open();
            return IsOpen;
        }
        private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (IsOpen) OnDataReceived(new RS232EventArgs(ReadExisting()));
        }
        /* ALTERNATIVE IMPLEMENTATION
        if (!serial.IsOpen) return; // If the com port has been closed, do nothing
        tempBuffer += serial.ReadExisting(); // Read all the data waiting in the buffer
        Console.WriteLine("tempBuffer:"+tempBuffer);
        var regex = @"{.*}";
        var complete = Regex.Match(tempBuffer, regex, RegexOptions.None);
        if (complete.Success) // If pattern not match, tempBuffer concats untill line ending pattern is received
        {
            var data = Regex.Match(tempBuffer, @"(?:[^{}]+)", RegexOptions.None);
            RS232EventArgs eArg = new RS232EventArgs();
            eArg.value = data.Value;
            OnDataReceived(eArg);
            tempBuffer = "";
        }
         */
        protected virtual void OnDataReceived(EventArgs e) => RS232DataReceived?.Invoke(this, e);
        #endregion
    }
}
