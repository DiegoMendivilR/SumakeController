using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SumakeController.Screens
{
    public partial class IOCard : Form
    {
        private USB5862 usb5862;
        public IOCard()
        {
            InitializeComponent();
            this.usb5862 = new USB5862("USB-5862,BID#1", this);
            foreach(Control control in panelIOCard.Controls)
            {
                if(control is System.Windows.Forms.Button)
                {
                    //((System.Windows.Forms.Button)control).BackColor = Theme.Blend(Theme.ContrastGray, Theme.EatonBlue, Theme.ThemeMultiplier);
                    ((System.Windows.Forms.Button)control).BackColor = Color.DarkGreen;
                    ((System.Windows.Forms.Button)control).FlatAppearance.BorderColor = Theme.EatonBlue;
                    ((System.Windows.Forms.Button)control).FlatAppearance.MouseDownBackColor = Theme.Blend(Theme.ContrastGray, Theme.EatonBlue, Theme.ThemeMultiplier);
                    ((System.Windows.Forms.Button)control).FlatAppearance.MouseOverBackColor = Theme.EatonBlue;
                }
            }
        }

        internal void ShowUpdate(byte data)
        {
            this.labelUpdate.Text = "Monitoring: " + data.ToString();
        }

        private void buttonOut_Click(object sender, EventArgs e)
        {

            if (sender is System.Windows.Forms.Button)
            {
                if (sender == buttonOut0) SetOut(0, 0, 1);
                if (sender == buttonOut1) SetOut(0, 1, 1);
                if (sender == buttonOut2) SetOut(0, 2, 1);
                if (sender == buttonOut3) SetOut(0, 3, 1);
                if (sender == buttonOut4) SetOut(0, 4, 1);
                if (sender == buttonOut5) SetOut(0, 5, 1);
                if (sender == buttonOut6) SetOut(0, 6, 1);
                if (sender == buttonOut7) SetOut(0, 7, 1);
                if (sender == buttonOut8) SetOut(1, 0, 1);
                if (sender == buttonOut9) SetOut(1, 1, 1);
                if (sender == buttonOut10) SetOut(1, 2, 1);
                if (sender == buttonOut11) SetOut(1, 3, 1);
                if (sender == buttonOut12) SetOut(1, 4, 1);
                if (sender == buttonOut13) SetOut(1, 5, 1);
                if (sender == buttonOut14) SetOut(1, 6, 1);
                if (sender == buttonOut15) SetOut(1, 7, 1);
            }
        }
        private async void SetOut(int port, int pin, int value)
        {
            Console.WriteLine(String.Format("Puerto:{0} Pin:{1} Valor:{2}",port+1,pin,value));
            await Task.Delay(5000);
        }

        private void buttonStartMonitoring_Click(object sender, EventArgs e)
        {
            usb5862.StartMonitoring();
        }

        private void buttonStopMonitoring_Click(object sender, EventArgs e)
        {
            labelUpdate.Text = "Monitoring: Off";
            usb5862.Flag = false;
        }
    }
}
