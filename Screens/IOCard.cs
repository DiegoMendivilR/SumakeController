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
        private UsbDaq daq;
        public IOCard()
        {
            InitializeComponent();
            this.daq = new UsbDaq("USB-5862,BID#1");
            daq.Port0Update += OnPort0Update;
            daq.Port1Update += OnPort1Update;
            #region THEME
            foreach (Control control in panelIOCard.Controls)
            {
                if(control is System.Windows.Forms.Button)
                {
                    if(control == buttonStartMonitoring || control == buttonStopMonitoring)
                    {
                        ((System.Windows.Forms.Button)control).BackColor = Theme.EatonBlue;
                    }
                    else
                    {
                        ((System.Windows.Forms.Button)control).BackColor = Theme.ContrastGray;
                        ((System.Windows.Forms.Button)control).FlatAppearance.BorderColor = Theme.EatonBlue;
                        ((System.Windows.Forms.Button)control).FlatAppearance.MouseDownBackColor = Theme.ContrastGray;
                        ((System.Windows.Forms.Button)control).FlatAppearance.MouseOverBackColor = Theme.EatonBlue;
                    }
                }
            }
            #endregion
        }
        private void OnPort0Update(object sender, EventArgs e) => labelPort0.Text = ((UsbDaq)sender).DataPort0.ToString();
        private void OnPort1Update(object sender, EventArgs e) => labelPort1.Text = ((UsbDaq)sender).DataPort1.ToString();
        private void buttonOut_Click(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Button)
            {
                if (sender == buttonOut0) ToggleButtonActivation(sender, 0, 0);
                if (sender == buttonOut1) ToggleButtonActivation(sender, 0, 1);
                if (sender == buttonOut2) ToggleButtonActivation(sender, 0, 2);
                if (sender == buttonOut3) ToggleButtonActivation(sender, 0, 3);
                if (sender == buttonOut4) ToggleButtonActivation(sender, 0, 4);
                if (sender == buttonOut5) ToggleButtonActivation(sender, 0, 5);
                if (sender == buttonOut6) ToggleButtonActivation(sender, 0, 6);
                if (sender == buttonOut7) ToggleButtonActivation(sender, 0, 7);
                if (sender == buttonOut8) ToggleButtonActivation(sender, 1, 0);
                if (sender == buttonOut9) ToggleButtonActivation(sender, 1, 1);
                if (sender == buttonOut10) ToggleButtonActivation(sender, 1, 2);
                if (sender == buttonOut11) ToggleButtonActivation(sender, 1, 3);
                if (sender == buttonOut12) ToggleButtonActivation(sender, 1, 4);
                if (sender == buttonOut13) ToggleButtonActivation(sender, 1, 5);
                if (sender == buttonOut14) ToggleButtonActivation(sender, 1, 6);
                if (sender == buttonOut15) ToggleButtonActivation(sender, 1, 7);
            }
        }
        private void ToggleButtonActivation(object sender, int port, int pin)
        {
            if(sender is System.Windows.Forms.Button)
            {
                Color color;
                if (((System.Windows.Forms.Button)(sender)).BackColor == Theme.ContrastGray)
                    color = Theme.EatonBlue;
                else
                    color = Theme.ContrastGray;
                ((System.Windows.Forms.Button)(sender)).BackColor = color;
                daq.WritePort(port, pin, color == Theme.ContrastGray ? 0 : 1);
            }
        }
        private void buttonStartMonitoring_Click(object sender, EventArgs e) => daq.StartMonitoring();
        private void buttonStopMonitoring_Click(object sender, EventArgs e)
        {
            labelPort0.Text = "Port0: Off";
            labelPort1.Text = "Port1: Off";
            daq.StopMonitoring = false;
        }
        public void ResetOutput() => daq.ResetOutput();
    }
}
