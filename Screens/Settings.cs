using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SumakeController.Screens
{
    public partial class Settings : Form
    {
        SMTC1RS232 serialPort;
        public Settings(SMTC1RS232 serialPort)
        {
            this.serialPort = serialPort;
            InitializeComponent();
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

            numericDeviceId.Value = serialPort.DeviceID;
            comboMode.Text = serialPort.Mode.ToString();
            comboLanguage.Text = serialPort.Language.ToString();
            comboOkAllSignal.Text = serialPort.OkAllSignal.ToString();
            comboBatchMode.Text = serialPort.BatchMode.ToString();
            comboTorqueUnit.Text = serialPort.TorqueUnit.ToString();
            comboGateMode.Text = serialPort.GateMode.ToString();
            comboBuzzerMode.Text = serialPort.BuzzerMode.ToString();
            comboLedMode.Text = serialPort.LedMode.ToString();
            comboStartMode.Text = serialPort.StartMode.ToString();
            comboBarcodeEnable.Text = serialPort.BarcodeEnable.ToString();
            comboStartSignalMode.Text = serialPort.StartSignalMode.ToString();
            comboInternetSettings.Text = serialPort.InternetSettings.ToString();

            foreach (Control control in tablePanel.Controls)
            {
                if (control is ComboBox)
                {
                    ((ComboBox)control).DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
            foreach (Control control in tablePanel.Controls)
            {
                if (control is System.Windows.Forms.Button)
                {
                    System.Windows.Forms.Button button = ((System.Windows.Forms.Button)control);
                    button.BackColor = Theme.Blend(Theme.ContrastGray, Theme.EatonBlue, Theme.ThemeMultiplier);
                    FlatButtonAppearance appearance = button.FlatAppearance;
                    appearance.MouseOverBackColor = Theme.EatonBlue;
                    appearance.MouseDownBackColor = Theme.Blend(Theme.ContrastGray, Theme.EatonBlue, Theme.ThemeMultiplier);
                }
            }
            //LABELS
            foreach (Control control in tablePanel.Controls)
            {
                if (control is System.Windows.Forms.Label)
                {
                    ((Label)control).ForeColor = Theme.EatonBlue;
                }
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            serialPort.DeviceID = Decimal.ToInt32(numericDeviceId.Value);
            serialPort.Mode = (Mode)Enum.Parse(typeof(Mode), comboMode.Text);
            serialPort.Language = (Language)Enum.Parse(typeof(Language), comboLanguage.Text);
            serialPort.OkAllSignal = (OkAllSignal)Enum.Parse(typeof(OkAllSignal), comboOkAllSignal.Text);
            serialPort.BatchMode = (BatchMode)Enum.Parse(typeof(BatchMode), comboBatchMode.Text);
            serialPort.TorqueUnit = (TorqueUnit)Enum.Parse(typeof(TorqueUnit), comboTorqueUnit.Text);
            serialPort.GateMode = (GateMode)Enum.Parse(typeof(GateMode), comboGateMode.Text);
            serialPort.BuzzerMode = (BuzzerMode)Enum.Parse(typeof(BuzzerMode), comboBuzzerMode.Text);
            serialPort.LedMode = (LedMode)Enum.Parse(typeof(LedMode), comboLedMode.Text);
            serialPort.StartMode = (StartMode)Enum.Parse(typeof(StartMode), comboStartMode.Text);
            serialPort.BarcodeEnable = (BarcodeEnable)Enum.Parse(typeof(BarcodeEnable), comboBarcodeEnable.Text);
            serialPort.StartSignalMode = (StartSignalMode)Enum.Parse(typeof(StartSignalMode), comboStartSignalMode.Text);
            serialPort.CMD103();
            //logSettings();
        }
        private void logSettings()
        {
            Console.WriteLine(String.Format(stringCommandHelper(12),serialPort.DeviceID,serialPort.Mode,serialPort.Language,serialPort.OkAllSignal,serialPort.BatchMode,serialPort.TorqueUnit,serialPort.GateMode,serialPort.BuzzerMode,serialPort.LedMode,serialPort.StartMode,serialPort.BarcodeEnable,serialPort.StartSignalMode));
            Console.WriteLine(String.Format(stringCommandHelper(12),(int)serialPort.DeviceID,(int)serialPort.Mode,(int)serialPort.Language,(int)serialPort.OkAllSignal,(int)serialPort.BatchMode,(int)serialPort.TorqueUnit,(int)serialPort.GateMode,(int)serialPort.BuzzerMode,(int)serialPort.LedMode,(int)serialPort.StartMode,(int)serialPort.BarcodeEnable,(int)serialPort.StartSignalMode));
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
    }
}
