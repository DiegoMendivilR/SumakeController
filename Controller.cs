/*
 * #TODO: The todo list
 * The purpose of this program is to control and receive data from the SMT-C1 Automatic Screwdriver throug the RS232 port and store the relevant information in a database for traceability
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CESATAutomationDevelop.Properties;
using System.Resources;
using CESATAutomationDevelop.Screens;
using System.CodeDom;
using System.Media;

namespace CESATAutomationDevelop
{
    #region ENUMS
    enum DeviceName { AMS, DAS }
    enum BatchMode { Decrease, Increase }
    enum BarcodeEnable { On, Off }
    enum BuzzerMode { On, Off }
    enum Unused { Default }
    enum GateMode { Off, Once, Twice }
    enum Language { English, Chinese }
    /// <summary>
    /// Sets the tool led mode
    /// <list type="bullet">
    /// <item>
    /// <term>Off</term>
    /// <description>The led is always turned off.</description>
    /// </item>
    /// <item>
    /// <term>Start</term>
    /// <description>Start lighting.</description>
    /// </item>
    /// <item>
    /// <term>Start</term>
    /// <description>Continuos lighting.</description>
    /// </item>
    /// </list>
    /// </summary>
    enum LedMode { Off, Start, On }
    enum OkAllSignal { Once, Each }
    enum Mode { [Description("Connection")] ADV, [Description("Standalone")] STD, [Description("Alignment")] ALI, [Description("Setting")] SET }
    enum TorqueUnit { Kgfm, Nm, Kgfcm, Lbin }
    enum StartMode { Both, Lever, Push }
    enum StartSignalMode { Motor, Trigger }
    enum InternetSettings { WIFI, LAN, RS232 }
    enum ScrewdriverStatus { DisableBoth, EnableFWD, EnableREV, EnableBoth }
    enum TargetCondition { NA, Thread, Torque }
    enum Direction { CW, CCW }
    enum OkAllStop { Off, On }
    enum Select { NA, TS, TP, Job }
    enum ControllerState { NoCondition, ScrewCountClear, EnableScrewdriver, DisableScrewdriver, ResetController, ResetJobSequence }
    enum ScrewdriverMode { NoCondition, NSASConfirmToEnable }
    enum InterfaceType { USB, RS232, RS485 }
    #endregion
    public partial class Controller : Form
    {
        #region PROPERTIES
        private SerialSmtC1 serialPort;
        private Serie serie = new Serie();
        String connectionString = ConfigurationManager.ConnectionStrings["think"].ConnectionString;
        private Form activeForm;
        private System.Windows.Forms.Button selectedButtonScreen;
        public RS232 serial;
        public UsbDaq daq;
        public SmtC1 smtC1;
        public CobotSimulated cobot;
        public string tempBuffer = "";
        private string tempCommand = "";
        private int piece = 0;
        private bool tightenSaved = false;
        #endregion
        #region WINDOW BORDERLESS MOVE AND RESIZE VARIABLES
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private const int cGrip = 16;
        private const int cCaption = 32;
        #endregion
        #region CONSTRUCTOR
        public Controller()
        {
            InitializeComponent();
            ChasisScrewing chasisScrewing = new ChasisScrewing();
            chasisScrewing.OnTextBoxScan += ChasisScrewing_OnTextBoxScan;
            PanelContentAddForm(chasisScrewing);
            /*
            smtC1 = new SmtC1();
            serial = new RS232("COM6");
            daq = new UsbDaq("USB-5862,BID#1");
            cobot = new CobotSimulated();

            smtC1.PropertyChanged += new PropertyChangedEventHandler(SmtC1_PropertyChanged);
            smtC1.TighteningDataReceived += new EventHandler(SmtC1_TighteningDataReceived);
            serial.RS232DataReceived += new EventHandler(RS232_OnDataReceived);
            //daq.Port0Update = new EventHandler(Daq_Port0Changed);

            Task.Delay(2500).ContinueWith((task) => { //Engage Screwdriver ref: Brant mail -> Meeting for SMT-CI
                serial.Write(smtC1.CMD100());
            });

            Form simulation = new Screens.Simulation();
            simulation.TopLevel = false;
            simulation.FormBorderStyle = FormBorderStyle.None;
            simulation.Dock = DockStyle.Fill;
            panelContent.Controls.Add(simulation);
            panelContent.Tag = simulation;
            simulation.BringToFront();
            simulation.Show();
            (simulation as Screens.Simulation).Scanning += new EventHandler(Simulation_Scan);
            (simulation as Screens.Simulation).StartSimulation += new EventHandler(Simulation_Start);
            (simulation as Screens.Simulation).PropertyChanged += new PropertyChangedEventHandler(Simulation_PropertyChanged);
            */

            this.SetStyle(ControlStyles.ResizeRedraw, true);
            ThemeColor();
        }

        private void ChasisScrewing_OnTextBoxScan(object sender, EventArgs e)
        {
            if ((e as KeyEventArgs).KeyCode == Keys.Enter) {
                Console.WriteLine("Scanned");
            }
        }
        #endregion
        private void PanelContentAddForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContent.Controls.Add(form);
            panelContent.Tag = form;
            form.BringToFront();
            form.Show();
        }
        private void Simulation_PropertyChanged(object sender, PropertyChangedEventArgs e) =>
            ((sender as Screens.Simulation).Controls.Find("buttonSave", true)[0] as System.Windows.Forms.Button).Enabled = !(sender as Screens.Simulation).SimulationRunning;
        private async void SmtC1_TighteningDataReceived(object sender, EventArgs e)
        {
            Console.WriteLine("SmtC1_TighteningDataReceived");
            if (piece > 0)
            {
                string[] parameters =(e as IRS232Data100EventArgs).Parameters;
                var query = String.Format("INSERT INTO [CESAT].[dbo].[TighteningData] ([Date],[IdSerie],[DeviceID],[ScrewSerial],[DeviceSerial],[Job],[Js],[Ts],[ProgramName],[TorqueUnit],[FasteningTimeMs],[FasteningThread],[RemainingScrews],[TotalScrews],[FasteningStatus],[NSAS]) VALUES (GETDATE(),{14},{0},'{1}','{2}',{3},{4},{5},'{6}',{7},{8},{9},{10},{11},'{12}',{13})", parameters[10], parameters[11], parameters[12], parameters[14], parameters[15], parameters[16], parameters[17], parameters[20], parameters[21], parameters[22], Int32.Parse(parameters[23].Substring(0, 2)), Int32.Parse(parameters[23].Substring(3)), parameters[25], parameters[26], piece);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(query, connection);
                    using (SqlDataReader datareader = await command.ExecuteReaderAsync())
                        if (datareader.Read())
                            Console.WriteLine("datareader[\"id\"]"+datareader["id"]);
                }
                Console.WriteLine(".");
                tightenSaved = true;
            }
        }
        private async void Simulation_Scan(object sender, EventArgs e)
        {
            if ((e as KeyEventArgs).KeyCode == Keys.Return)
            {
                
                var query = String.Format("INSERT INTO CESAT.dbo.Series OUTPUT Inserted.Id VALUES ('{0}',GETDATE(),1)", (sender as System.Windows.Forms.TextBox).Text);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(query, connection);
                    using (SqlDataReader datareader = await command.ExecuteReaderAsync())
                        if (datareader.Read())
                            this.piece = (int)datareader["id"];
                }
            }
        }
        public async void Simulation_Start(object sender, EventArgs e)
        {
            Screens.Simulation senderForm = (sender as Control).FindForm() as Screens.Simulation;
            senderForm.SimulationRunning = true;
            if (piece == 0)
            {
                ShowMessage("Escanee una serie primero.", "Sin serie.");
            } else
            {
                int writeDelay = 150; //relay is 150ms delay
                int scannDelay = 25;
                int tightenSavedDelay = 50;
                List<Image> images = new List<Image>() { Properties.Resources.cover_scw1, Properties.Resources.cover_scw2, Properties.Resources.cover_scw3, Properties.Resources.cover_scw4, Properties.Resources.cover };
                //resetear interfaz
                Console.WriteLine("IO Reset");
                daq.ResetOutput();
                //Simulation
                Console.WriteLine("Start");

                int tr = 0;
                do
                {
                    senderForm.SimulationImage(images[tr]);

                    daq.WriteBit(1, 0, 1);//set robot moving
                    Console.WriteLine("Cobot on");
                    //await Task.Delay(writeDelay);
                    while (daq.ReadBit(1, 7) == 0) await Task.Delay(scannDelay); //waiting cobot stop moving
                    daq.WriteBit(1, 0, 0);//reset moving
                    Console.WriteLine("Cobot off");

                    if(tr > 0)
                    {
                        while (!tightenSaved)
                        {
                            Console.WriteLine(".");
                            await Task.Delay(tightenSavedDelay); //Waiting tighten response
                        }
                        tightenSaved = false;
                    }


                    daq.WriteBit(0, 0, 1);
                    Console.WriteLine("Screw on ");
                    await Task.Delay(writeDelay);


                    while(daq.DataPort0==0x0) await Task.Delay(scannDelay);
                    daq.WriteBit(0, 0, 0);
                    Console.WriteLine("Screw off");


                    tr++;
                    Console.WriteLine("daq.ReadBit(0,2) == 0:"+ (daq.ReadBit(0, 2) == 0));
                }while (daq.ReadBit(0,2) == 0);

                senderForm.SimulationImage(images[images.Count-1]);

                Console.WriteLine("Cobot returning on");
                daq.WriteBit(1, 1, 1);//set robot moving
                //await Task.Delay(writeDelay);
                while (daq.ReadBit(1, 7) == 0) await Task.Delay(scannDelay); //waiting cobot stop moving
                Console.WriteLine("Cobot returning off");
                daq.WriteBit(1, 1, 0);//reset robot moving


                while (!tightenSaved)
                {
                    Console.WriteLine(".");
                    await Task.Delay(tightenSavedDelay); //Waiting tighten response
                }
                tightenSaved = false;

                Console.WriteLine("End");
                //resetear interfaz
                Console.WriteLine("IO Reset");
                daq.ResetOutput();
                piece = 0;
                Control[] controls = senderForm.Controls.Find("txtInput", true);
                (controls[0] as System.Windows.Forms.TextBox).Text = String.Empty;
            }
            senderForm.SimulationRunning = false;
        }
        private void SmtC1_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case "Job":  Console.WriteLine("Job:"+(sender as SmtC1).Job);
                    break;
                case "TighteningProgram":  Console.WriteLine("TighteningProgram:" + (sender as SmtC1).TighteningProgram);
                    break;
                default:
                    break;
            }
        }
        //private void Daq_Port0Changed(object sender, EventArgs e) => Console.Write(""/*String.Format("OnPort0Update: {0}", (sender as UsbDaq).DataPort0)*/);
        private void RS232_OnDataReceived(object sender, EventArgs e)
        {
            string data = (e as RS232EventArgs).value;
            if (serial.IsOpen && ValidateCommand(data))
                tempBuffer = smtC1.Listener(CommandParameters(data));
            else
                tempBuffer += data;
        }
        private bool ValidateCommand(string data)
        {
            if(Regex.Match(data, @"{.*}", RegexOptions.None).Success && tempCommand != data) // If pattern not match, wait for the line ending pattern to proccess
            {
                tempCommand = data;
                return true;
            }
            else
            {
                return false;
            }
        }
        private string CommandParameters(string data) => Regex.Match(data, @"(?:[^{}]+)", RegexOptions.None).Value;
        #region FORM THEME
        private void ThemeColor()
        {
            //PANELS
            panelTitle.BackColor = Theme.EatonBlue;
            panelMenu.BackColor = Theme.ContrastGray;
            panelLogo.BackColor = Theme.Blend(Theme.ContrastGray, Theme.EatonBlue, Theme.ThemeMultiplier);
            panelRight.BackColor = Theme.EatonBlue;
            panelBottom.BackColor = Theme.ContrastGray;
            //LABELS
            foreach(Control control in panelContent.Controls)
            {
                if(control is System.Windows.Forms.Label)
                {
                    ((Label)control).ForeColor = Theme.EatonBlue;
                }
            }

            //BUTTONS
            //buttonCloseTab.Visible = false;
            foreach (Control control in panelMenu.Controls)
            {
                if (control is System.Windows.Forms.Button)
                {
                    FlatButtonAppearance appearance = ((System.Windows.Forms.Button)control).FlatAppearance;
                    appearance.MouseOverBackColor = Theme.EatonBlue;
                    appearance.MouseDownBackColor = Theme.Blend(Theme.ContrastGray, Theme.EatonBlue, Theme.ThemeMultiplier);
                }
            }
        }
        #endregion
        #region WINDOW BORDERLESS MOVE AND RESIZE METHOD
        protected override void WndProc(ref Message m)
        {
            if(m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if(pos.X>=this.ClientSize.Width-cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }
        #endregion
        #region CONTROLLER METHODS
        private void SetButtonColors(System.Windows.Forms.Button sender)
        {
            foreach(Control control in panelMenu.Controls)
            {
                if(control is System.Windows.Forms.Button)
                {
                    //Console.WriteLine(control.Name);
                    System.Windows.Forms.Button btn = ((System.Windows.Forms.Button)control);
                    if(btn == sender)
                    {
                        btn.BackColor = Theme.Blend(Theme.ContrastGray, Theme.EatonBlue, Theme.ThemeMultiplier);
                        selectedButtonScreen = btn;
                        //buttonCloseTab.Visible = true;
                    }
                    else
                    {
                        btn.BackColor = Color.Transparent;
                    }
                }
            }
        }
        public void updateTorque(string torque)
        {
            //Screens.Monitoring monitoring = (Screens.Monitoring)activeForm;
            //monitoring.SetTorque(torque);
            //ThreadHelperClass.SetText(this,lblTorque,torque);
        }
        public int getIDSerie()
        {
            return serie.Id;
        }
        public void JobChanged(bool changed)
        {
            if(changed)
            {
                //ThreadHelperClass.SetText(this, lblChangeJob, changed ? "OK": "ERROR");
            }
        }
        public void OpenPortFirst()
        {
            MessageBox.Show("Primero abra el puerto de comunicación.", "Puerto cerrado.", MessageBoxButtons.OK);
        }
        public void ShowMessage(string text, string caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK);
        }
        internal void UpdateUi()
        {
            foreach(Control control in panelContent.Controls)
            {
                if(control is Screens.Monitoring)
                {
                    //((Screens.Monitoring)control).UpdateUi(sumakeRS232.Job.ToString(), sumakeRS232.JobSequence.ToString(), sumakeRS232.TighteningProgram.ToString(), sumakeRS232.ScrewdriverIDCode.ToString(), sumakeRS232.ScrewdriverStatus.ToString());
                    ((Screens.Monitoring)control).UpdateUi();
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelContent.Controls.Add(childForm);
            this.panelContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        #endregion
        #region METHODS FOR CONTROL EVENTS
        /// <summary>
        /// Closing the entire application from a button within the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            foreach (Control control in panelContent.Controls)
                if (control is Screens.IOCard)
                    ((Screens.IOCard)control).ResetOutput();
        }
        /// <summary>
        /// Close the serial port before closing the application. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SMTC1Controller_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort?.ClosePort();
        }
        /// <summary>
        /// Capture the mouse movement in the panel title for move the window across the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach(Control control in panelContent.Controls)
            {
                if(control is System.Windows.Forms.Form)
                {
                    if (((System.Windows.Forms.Form)control) is Screens.Monitoring && sender == buttonMonitor)
                    {
                        control.BringToFront();
                        SetButtonColors((System.Windows.Forms.Button)sender);
                        found = true;
                        break;
                    }
                    if (((System.Windows.Forms.Form)control) is Screens.Settings && sender == buttonSettings)
                    {
                        control.BringToFront();
                        SetButtonColors((System.Windows.Forms.Button)sender);
                        found = true;
                        break;
                    }
                    /*
                    if (((System.Windows.Forms.Form)control) is Screens.IOCard && sender == buttonIOCard)
                    {
                        control.BringToFront();
                        SetButtonColors((System.Windows.Forms.Button)sender);
                        found = true;
                        break;
                    }
                    */
                }
            }
            if(found == false || panelContent.Controls.Count == 0)
            {
                if (sender == buttonMonitor)
                {
                    OpenChildForm(new Screens.Monitoring(serialPort),sender);
                    SetButtonColors((System.Windows.Forms.Button)sender);
                }
                else if (sender == buttonSettings)
                {
                    if(SearchPanelContent(typeof(Screens.Monitoring)) && serialPort.IsOpen)
                    {
                        OpenChildForm(new Screens.Settings(serialPort),sender);
                        SetButtonColors((System.Windows.Forms.Button)sender);
                    }
                    else
                    {
                        MessageBox.Show("Primero abra el puerto de comunicación.", "Puerto cerrado.", MessageBoxButtons.OK);
                    }
                }
                /*
                else if (sender == buttonIOCard)
                {
                    if (SearchUSBIO("VID_1809&PID_5862"))
                    {
                        OpenChildForm(new Screens.IOCard(), sender);
                        SetButtonColors((System.Windows.Forms.Button)sender);
                    }
                    else
                    {
                        MessageBox.Show("Conecte el dispositivo.", "Dispositivo desconectado.", MessageBoxButtons.OK);
                    }
                }
                */
            }
        }
        private bool SearchUSBIO(string name)
        {
            var usbDevices = USBDeviceInfo.GetUSBDevices();
            foreach (var usbDevice in usbDevices)
            {
                Console.WriteLine("Device ID: {0}, PNP Device ID: {1}, Description: {2}",
                    usbDevice.DeviceID, usbDevice.PnpDeviceID, usbDevice.Description);
                Console.WriteLine(usbDevice.DeviceID.Contains(name));
                if (usbDevice.DeviceID.Contains(name)) return true;
            }
            return false;
        }
        private bool SearchPanelContent(Type type)
        {
            foreach (Control control in panelContent.Controls)
                if (control is System.Windows.Forms.Form && ((System.Windows.Forms.Form)control) is Screens.Monitoring)
                    return true;
            return false;
        }
        /// <summary>
        /// Capture the mouse movement in the label title for move the window across the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label12_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        /// <summary>
        /// Changes the buttonClose image when the mouse enter across the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_MouseEnter(object sender, EventArgs e)
        {
            buttonClose.BackgroundImage = Properties.Resources.icons8_close_window_96_red;
        }
        /// <summary>
        /// Changes the buttonClose image when the mouse leaves the button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_MouseLeave(object sender, EventArgs e)
        {
            buttonClose.BackgroundImage = Properties.Resources.icons8_close_window_96_gray;
        }
        /// <summary>
        /// Changes the buttonCloseTab image when the mouse enter across the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCloseTab_MouseEnter(object sender, EventArgs e)
        {
            //buttonCloseTab.BackgroundImage = Properties.Resources.icons8_close_96_tab_red;
        }
        /// <summary>
        /// Changes the buttonCloseTab image when the mouse leaves the button.
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// </summary>
        private void buttonCloseTab_MouseLeave(object sender, EventArgs e)
        {
            //buttonCloseTab.BackgroundImage = Properties.Resources.icons8_close_96_tab_white;
        }
        /// <summary>
        /// Closes the active screen selected in the left panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <summary>
        /// Closes the active screen selected in the left panel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCloseTab_Click(object sender, EventArgs e)
        {
            /*
            buttonCloseTab.Visible = false;
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }
             */
        }
        internal void UpdateSettings()
        {
            foreach (Control control in panelContent.Controls)
                if (control is Screens.Settings)
                    ((Screens.Settings)control).UpdateUi();
        }
        #endregion
    }
}
/* GET DATABASE RESPONSE EXAMPLE
private async void NewPiece(string piece)
{
    //var query = String.Format("INSERT INTO [CESAT].[dbo].[TighteningData] ([Date],[IdSerie],[DeviceID],[ScrewSerial],[DeviceSerial],[Job],[Js],[Ts],[ProgramName],[TorqueUnit],[FasteningTimeMs],[FasteningThread],[RemainingScrews],[TotalScrews],[FasteningStatus],[NSAS]) VALUES (GETDATE(),{14},{0},'{1}','{2}',{3},{4},{5},'{6}',{7},{8},{9},{10},{11},'{12}',{13})", parameters[10], parameters[11], parameters[12], parameters[14], parameters[15], parameters[16], parameters[17], parameters[20], parameters[21], parameters[22], Int32.Parse(parameters[23].Substring(0, 2)), Int32.Parse(parameters[23].Substring(3)), parameters[25], parameters[26], sMTC1Controller.getIDSerie());
    var query = String.Format("INSERT INTO CESAT.dbo.Series OUTPUT Inserted.Id VALUES ('{0}',GETDATE(),1)", piece);
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        await connection.OpenAsync();
        SqlCommand command = new SqlCommand(query, connection);
        //await command.ExecuteNonQueryAsync();
        using (SqlDataReader datareader = await command.ExecuteReaderAsync())
            if (datareader.Read())
                Console.WriteLine(datareader["id"]);

    }
}
 */
/* INSERT DATABASE EXAMPLE
private async void NewPiece(string piece)
{
    var query = String.Format("INSERT INTO CESAT.dbo.Series OUTPUT Inserted.Id VALUES ('{0}',GETDATE(),1)", piece);
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        await connection.OpenAsync();
        SqlCommand command = new SqlCommand(query, connection);
        await command.ExecuteNonQueryAsync();
    }
}
 */