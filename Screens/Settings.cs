using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CESATAutomationDevelop.Screens
{
    public partial class Settings : Form
    {
        RS232 serial;
        SmtC1 smt;
        public Settings(RS232 serial, SmtC1 smt)
        {
            this.serial = serial;
            InitializeComponent();

            comboPorts.DataSource = SerialPort.GetPortNames();
            comboMode.DataSource = Enum.GetNames(typeof(Mode));
            comboLanguage.DataSource = Enum.GetNames(typeof(Language));
            comboOkAllSignal.DataSource = Enum.GetNames(typeof(OkAllSignal));
            comboBatchMode.DataSource = Enum.GetNames(typeof(BatchMode));
            comboTorqueUnit.DataSource = Enum.GetNames(typeof(TorqueUnit));
            comboGateMode.DataSource = Enum.GetNames(typeof(GateMode));
            comboBuzzerMode.DataSource = Enum.GetNames(typeof(BuzzerMode));
            comboLedMode.DataSource = Enum.GetNames(typeof(LedMode));
            comboStartMode.DataSource = Enum.GetNames(typeof(StartMode));
            comboBarcodeEnable.DataSource = Enum.GetNames(typeof(BarcodeEnable));
            comboStartSignalMode.DataSource = Enum.GetNames(typeof(StartSignalMode));
            comboInternetSettings.DataSource = Enum.GetNames(typeof(InternetSettings));

            foreach (Control control in tablePanel.Controls)
            {
                if (control is ComboBox)
                {
                    ((ComboBox)control).DropDownStyle = ComboBoxStyle.DropDownList;
                }
                if (control is System.Windows.Forms.Button)
                {
                    System.Windows.Forms.Button button = ((System.Windows.Forms.Button)control);
                    button.BackColor = Theme.Blend(Theme.ContrastGray, Theme.EatonBlue, Theme.ThemeMultiplier);
                    FlatButtonAppearance appearance = button.FlatAppearance;
                    appearance.MouseOverBackColor = Theme.EatonBlue;
                    appearance.MouseDownBackColor = Theme.Blend(Theme.ContrastGray, Theme.EatonBlue, Theme.ThemeMultiplier);
                }
                if (control is System.Windows.Forms.Label)
                {
                    ((Label)control).ForeColor = Theme.EatonBlue;
                }
                control.Enabled = false;
            }

            //serial.CMD108Delayed();
            Task.Delay(1500).ContinueWith((task) =>
            {
                EnableUI();
            });
        }
        public void EnableUI()
        {
            foreach (Control control in tablePanel.Controls)
                ThreadHelperClass.SetEnabled(this, control, true);
        }
        internal void UpdateUi()
        {
            ThreadHelperClass.SetText(this, comboBarcodeEnable, smt.BarcodeEnable.ToString());
            ThreadHelperClass.SetText(this, comboBatchMode, smt.BatchMode.ToString());
            ThreadHelperClass.SetText(this, comboTorqueUnit, smt.TorqueUnit.ToString());
            ThreadHelperClass.SetText(this, comboGateMode,smt.GateMode.ToString());
            ThreadHelperClass.SetText(this, comboMode, smt.Mode.ToString());
            ThreadHelperClass.SetText(this, comboStartSignalMode, smt.StartSignalMode.ToString());
            ThreadHelperClass.SetText(this, comboOkAllSignal, smt.OkAllSignal.ToString());
            ThreadHelperClass.SetText(this, comboInternetSettings, smt.InternetSettings.ToString());
            ThreadHelperClass.SetText(this, comboBuzzerMode, smt.BuzzerMode.ToString());
            ThreadHelperClass.SetText(this, comboLanguage, smt.Language.ToString());
            ThreadHelperClass.SetText(this, comboLedMode, smt.LedMode.ToString());
            ThreadHelperClass.SetText(this, comboStartMode, smt.StartMode.ToString());
            ThreadHelperClass.SetNumericUpDown(this, numericDeviceId, smt.DeviceID);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            smt.DeviceID = Decimal.ToInt32(numericDeviceId.Value);
            smt.Mode = (Mode)Enum.Parse(typeof(Mode), comboMode.Text);
            smt.Language = (Language)Enum.Parse(typeof(Language), comboLanguage.Text);
            smt.OkAllSignal = (OkAllSignal)Enum.Parse(typeof(OkAllSignal), comboOkAllSignal.Text);
            smt.BatchMode = (BatchMode)Enum.Parse(typeof(BatchMode), comboBatchMode.Text);
            smt.TorqueUnit = (TorqueUnit)Enum.Parse(typeof(TorqueUnit), comboTorqueUnit.Text);
            smt.GateMode = (GateMode)Enum.Parse(typeof(GateMode), comboGateMode.Text);
            smt.BuzzerMode = (BuzzerMode)Enum.Parse(typeof(BuzzerMode), comboBuzzerMode.Text);
            smt.LedMode = (LedMode)Enum.Parse(typeof(LedMode), comboLedMode.Text);
            smt.StartMode = (StartMode)Enum.Parse(typeof(StartMode), comboStartMode.Text);
            smt.BarcodeEnable = (BarcodeEnable)Enum.Parse(typeof(BarcodeEnable), comboBarcodeEnable.Text);
            smt.StartSignalMode = (StartSignalMode)Enum.Parse(typeof(StartSignalMode), comboStartSignalMode.Text);
            smt.CMD103();
            //logSettings();
        }
        private void logSettings()
        {
            Console.WriteLine(String.Format(stringCommandHelper(12),smt.DeviceID,smt.Mode,smt.Language,smt.OkAllSignal,smt.BatchMode,smt.TorqueUnit,smt.GateMode,smt.BuzzerMode,smt.LedMode,smt.StartMode,smt.BarcodeEnable,smt.StartSignalMode));
            Console.WriteLine(String.Format(stringCommandHelper(12),(int)smt.DeviceID,(int)smt.Mode,(int)smt.Language,(int)smt.OkAllSignal,(int)smt.BatchMode,(int)smt.TorqueUnit,(int)smt.GateMode,(int)smt.BuzzerMode,(int)smt.LedMode,(int)smt.StartMode,(int)smt.BarcodeEnable,(int)smt.StartSignalMode));
        }
        private string stringCommandHelper(int no)
        {
            string s = "";
            for (int x = 0; x < no; x++)
            {
                s += "{" + x + "},";
            }
            return s;
        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            /*
            if (serial.IsOpen) serial.ClosePort();
            else serial.OpenPort(comboPorts.Text);
            if (serial.IsOpen) btnOpenPort.Text = "&Close Port";
            else btnOpenPort.Text = "&Open Port";
            if (serial.IsOpen) serial.CMD100();

            serial.CMD121();
             */
        }
    }
}
