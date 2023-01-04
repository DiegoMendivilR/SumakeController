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
        private byte temp;
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
            byte data;
            while (Flag)
            {
                errorCode = dIn.Read(6, out data);
                if(data != temp)
                {
                    Console.WriteLine(temp);
                    Console.WriteLine(data);
                    temp = data;
                    ioCard.ShowUpdate(data);
                }
                await Task.Delay(75);
            }
        }
        public void StartMonitoring()
        {
            Flag = true;
            temp = 0;
            MonitoringInput();
        }

        private void dIn_Interrupt(object sender, DiSnapEventArgs e)
        {
            Flag = false;
        }
    }
}
