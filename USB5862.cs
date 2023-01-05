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
    public class USB5862
    {
        private InstantDiCtrl dIn = new InstantDiCtrl();
        private InstantDoCtrl dOut = new InstantDoCtrl();
        private string deviceDescription = "";
        private ErrorCode errorCode = ErrorCode.Success;
        private bool flag = true;
        private byte temp0;
        private byte temp1;
        IOCard ioCard;
        public USB5862(String deviceDescription, IOCard ioCard)
        {
            this.ioCard = ioCard;
            this.deviceDescription = deviceDescription;
            DeviceInformation deviceInformation = new DeviceInformation(deviceDescription);
            dIn.SelectedDevice = deviceInformation;
            dOut.SelectedDevice = deviceInformation;
            dIn.Interrupt += new EventHandler<DiSnapEventArgs>(dIn_Interrupt);
        }

        public bool Flag { get => flag; set => flag = value; }

        public async void MonitoringInput()
        {
            byte data0;
            byte data1;
            while (Flag)
            {
                errorCode = dIn.Read(0, out data0);
                errorCode = dIn.Read(1, out data1);
                if(data0 != temp0)
                {
                    Console.WriteLine("Port0, temp:" + temp0 + " data:"+ data0);
                    temp0 = data0;
                    ioCard.ShowUpdate(0, data0);
                }
                if (data1 != temp1)
                {
                    Console.WriteLine("Port1, temp:" + temp1 + " data:"+data1);
                    temp1 = data1;
                    ioCard.ShowUpdate(1, data1);
                }
                await Task.Delay(75);
            }
        }
        public void StartMonitoring()
        {
            Flag = true;
            temp0 = 0;
            temp1 = 0;
            MonitoringInput();
        }

        internal void ChangeOutput(int port, int pin, int value)
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
            Flag = false;
        }
    }
}
