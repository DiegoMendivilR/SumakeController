using Automation.BDaq;
using SumakeController.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SumakeController
{
    public class UsbDaq
    {
        private InstantDiCtrl dIn = new InstantDiCtrl();
        private InstantDoCtrl dOut = new InstantDoCtrl();
        DeviceInformation deviceInformation;
        private ErrorCode errorCode = ErrorCode.Success;
        private bool stopMonitoring = true;
        private byte temp0;
        private byte temp1;
        byte dataPort0;
        byte dataPort1;
        public EventHandler Port0Update;
        public EventHandler Port1Update;
        public UsbDaq(String deviceDescription)
        {
            deviceInformation = new DeviceInformation(deviceDescription);
            dIn.SelectedDevice = deviceInformation;
            dOut.SelectedDevice = deviceInformation;
            //dIn.Interrupt += new EventHandler<DiSnapEventArgs>(dIn_Interrupt);
        }
        protected virtual void OnPort0Update(EventArgs e) => Port0Update?.Invoke(this, e);
        protected virtual void OnPort1Update(EventArgs e) => Port1Update?.Invoke(this, e);
        public async void MonitoringInput()
        {
            while (StopMonitoring)
            {
                errorCode = dIn.Read(0, out dataPort0);
                errorCode = dIn.Read(1, out dataPort1);
                if(dataPort0 != temp0)
                {
                    OnPort0Update(EventArgs.Empty);
                    temp0 = dataPort0;
                }
                if (dataPort1 != temp1)
                {
                    OnPort1Update(EventArgs.Empty);
                    temp1 = dataPort1;
                }
                await Task.Delay(75);
            }
        }
        public void StartMonitoring()
        {
            StopMonitoring = true;
            temp0 = 0;
            temp1 = 0;
            MonitoringInput();
        }
        public bool StopMonitoring { get => stopMonitoring; set => stopMonitoring = value; }
        internal void WritePort(int port, int pin, int value)
        {
            errorCode = dOut.WriteBit(port,pin,(byte)value);
        }
        public void ResetOutput()
        {
            errorCode = dOut.Write(0, (byte)0x00);
            errorCode = dOut.Write(1, (byte)0x00);
        }
        private void dIn_Interrupt(object sender, DiSnapEventArgs e)
        {
            StopMonitoring = false;
        }
        public byte DataPort0 { get => dataPort0; set => dataPort0 = value; }
        public byte DataPort1 { get => dataPort1; set => dataPort1 = value; }
    }
}
