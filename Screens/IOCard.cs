using Automation.BDaq;
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
                    if(control == buttonStartMonitoring || control == buttonStopMonitoring)
                    {
                        ((System.Windows.Forms.Button)control).BackColor = Theme.EatonBlue;
                    }
                    else
                    {
                        //((System.Windows.Forms.Button)control).BackColor = Theme.Blend(Theme.ContrastGray, Theme.EatonBlue, Theme.ThemeMultiplier);
                        ((System.Windows.Forms.Button)control).BackColor = Theme.ContrastGray;
                        ((System.Windows.Forms.Button)control).FlatAppearance.BorderColor = Theme.EatonBlue;
                        ((System.Windows.Forms.Button)control).FlatAppearance.MouseDownBackColor = Theme.ContrastGray;
                        ((System.Windows.Forms.Button)control).FlatAppearance.MouseOverBackColor = Theme.EatonBlue;
                    }
                }
            }
        }

        internal void ShowUpdate(int sourcePort, byte portData)
        {
            if(sourcePort==0)
                this.labelPort0.Text = "Port0: " + portData.ToString();
            else
                this.labelPort1.Text = "Port1: " + portData.ToString();
        }

        private void buttonOut_Click(object sender, EventArgs e)
        {

            if (sender is System.Windows.Forms.Button)
            {
                if (sender == buttonOut0) ChangeOut(sender, 0, 0);
                if (sender == buttonOut1) ChangeOut(sender, 0, 1);
                if (sender == buttonOut2) ChangeOut(sender, 0, 2);
                if (sender == buttonOut3) ChangeOut(sender, 0, 3);
                if (sender == buttonOut4) ChangeOut(sender, 0, 4);
                if (sender == buttonOut5) ChangeOut(sender, 0, 5);
                if (sender == buttonOut6) ChangeOut(sender, 0, 6);
                if (sender == buttonOut7) ChangeOut(sender, 0, 7);
                if (sender == buttonOut8) ChangeOut(sender, 1, 0);
                if (sender == buttonOut9) ChangeOut(sender, 1, 1);
                if (sender == buttonOut10) ChangeOut(sender, 1, 2);
                if (sender == buttonOut11) ChangeOut(sender, 1, 3);
                if (sender == buttonOut12) ChangeOut(sender, 1, 4);
                if (sender == buttonOut13) ChangeOut(sender, 1, 5);
                if (sender == buttonOut14) ChangeOut(sender, 1, 6);
                if (sender == buttonOut15) ChangeOut(sender, 1, 7);
            }
        }
        private void ChangeOut(object sender, int port, int pin)
        {
            if(sender is System.Windows.Forms.Button)
            {
                Color color;
                if (((System.Windows.Forms.Button)(sender)).BackColor == Theme.ContrastGray)
                    color = Theme.EatonBlue;
                else
                    color = Theme.ContrastGray;
                ((System.Windows.Forms.Button)(sender)).BackColor = color;
                Console.WriteLine(String.Format("Port{0} Pin:{1} Valor:{2}",port+1,pin,color==Theme.ContrastGray ?0:1));
                usb5862.ChangeOutput(port, pin, color == Theme.ContrastGray ? 0 : 1);
            }
        }

        private void buttonStartMonitoring_Click(object sender, EventArgs e)
        {
            usb5862.StartMonitoring();
        }

        private void buttonStopMonitoring_Click(object sender, EventArgs e)
        {
            labelPort0.Text = "Port0: Off";
            labelPort1.Text = "Port1: Off";
            usb5862.Flag = false;
        }
        public void ResetOutput()
        {
            usb5862.ResetOutput();
        }
    }
}
