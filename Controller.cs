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
    public partial class Controller : Form
    {
        private SMTC1RS232 serialPort;
        private Serie serie = new Serie();
        String connectionString = ConfigurationManager.ConnectionStrings["think"].ConnectionString;
        private Form activeForm;
        private System.Windows.Forms.Button selectedButtonScreen;

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

        public Controller()
        {
            InitializeComponent();
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            serialPort = new SMTC1RS232(this);
            //usb5862 = new USB5862("USB-5862,BID#1");
            //STYLES
            ThemeColor();
            /*
            EAACTDSRS232 eaaSerial = new EAACTDSRS232(this);
            eaaSerial.showmethemagic();
             */
        }

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
        public string rollbackQuery(String query)
        {
            return String.Format("begin transaction test {0} rollback transaction test", query);
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
            serialPort.ClosePort();
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
                    if (((System.Windows.Forms.Form)control) is Screens.IOCard && sender == buttonIOCard)
                    {
                        control.BringToFront();
                        SetButtonColors((System.Windows.Forms.Button)sender);
                        found = true;
                        break;
                    }
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